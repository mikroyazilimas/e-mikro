using E_Mikro.Library;
using E_Mikro.Models;
using E_Mikro.Models.Contentful;
using E_Mikro.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace E_Mikro.Controllers
{
    public class FormController : Base
    {
        [HttpPost] 
        public async Task<ActionResult> HomePageContact(ContactForm model)
        {
            if (model.FirstName.Split(' ').Length > 1)
                model.LastName = model.FirstName.Substring(model.FirstName.Split(' ')[0].Length + 1, (model.FirstName.Length - model.FirstName.Split(' ')[0].Length) - 1);
            else
                model.LastName = "";

            ContactFormSalesForce(model);
            model.IPAddress = Tools.GetIpAddress;
            await ContentfulAPI.Management.AddContactForm(model);
            return Redirect("/tesekkurler");
        }

        [HttpPost]
        public async Task<ActionResult> Contact(Page model)
        {
            ContactFormSalesForce(model.ContactForm);
            model.ContactForm.IPAddress = Tools.GetIpAddress;
            await ContentfulAPI.Management.AddContactForm(model.ContactForm);
            return Redirect("/tesekkurler");
        }

        public void ContactFormSalesForce(ContactForm model)
        {
            MailHelper mail = new MailHelper();
            LogProcess logProcess = new LogProcess();
            //RestApiService restApi = new RestApiService();

            //string gclid = Tools.GetQueryStringValueFromUrlReferrer("gclid") ?? Tools.GetQueryStringValueFromRawUrl("gclid");
            //string utm_campaign = Tools.GetQueryStringValueFromUrlReferrer("utm_campaign") ?? Tools.GetQueryStringValueFromRawUrl("utm_campaign");
            //string utm_medium = Tools.GetQueryStringValueFromUrlReferrer("utm_medium") ?? Tools.GetQueryStringValueFromRawUrl("utm_medium");
            //string utm_source = Tools.GetQueryStringValueFromUrlReferrer("utm_source") ?? Tools.GetQueryStringValueFromRawUrl("utm_source");

            try
            {
                //if (String.IsNullOrEmpty(gclid))
                //    gclid = Tools.GetCookieValue(Names.Cookie.Gclid);

                //if (String.IsNullOrEmpty(utm_campaign))
                //    utm_campaign = Tools.GetCookieValue(Names.Cookie.UtmCampaign);

                //if (String.IsNullOrEmpty(utm_medium))
                //    utm_medium = Tools.GetCookieValue(Names.Cookie.UtmMedium);

                //if (String.IsNullOrEmpty(utm_source))
                //    utm_source = Tools.GetCookieValue(Names.Cookie.UtmSource);

                //Input_RequestForm inpt = new Input_RequestForm
                //{
                //    firstName = model.FirstName,
                //    lastName = model.LastName,
                //    email = model.Email,
                //    phone = model.Phone,
                //    city = "",
                //    company = (model.CompanyTitle == null ? model.CompanyName : model.CompanyTitle) ?? "company",
                //    status = "New",
                //    leadSource = "Demo Request",
                //    gclid = gclid,
                //    utmCampaign = utm_campaign,
                //    utmMedium = utm_medium,
                //    utmSource = utm_source,
                //    formNotes = model.Message,
                //    izinDurumu = model.DataSharing ? "Izinli" : "Izinsiz"
                //};
                //inpt.phone = "0" + inpt.phone.TrimStart('0').Replace("(", "").Replace(")", "").Replace(" ", "");

                //Output_DemoRequest resp = restApi.DemoRequestForm(inpt);
                string body = String.Empty;
                using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/Templates/Mail/contact.html"), System.Text.Encoding.UTF8))
                    body = sr.ReadToEnd();

                body = body.Replace("@@ad@@", model.FirstName);
                body = body.Replace("@@soyad@@", model.LastName);
                body = body.Replace("@@firma@@", model.CompanyTitle == null ? model.CompanyName : model.CompanyTitle);
                body = body.Replace("@@eposta@@", model.Email);
                body = body.Replace("@@telefon@@", model.Phone);
                body = body.Replace("@@konu@@", model.Subject);
                body = body.Replace("@@mesaj@@", model.Message);

                mail.To = new List<string>() { "no-reply@e-mail.mikro.com.tr", "Mert.ALANKAYA@mikro.com.tr", "satis@emikro.com.tr" };
                mail.From = "no-reply@e-mail.mikro.com.tr";
                mail.FromDisplayName = "E-Mikro";
                mail.Body = body;
                mail.Subject = "E-MİKRO - Bize Ulaşın Formu";
                bool rtn = mail.SendMail();
                if (!rtn)
                    logProcess.WriteLog("Mail Gönderirken hata oluştu <br> " + body);
            }
            catch (Exception ex)
            {
                mail.To = new List<string>() { "emre.gultekin@h.com.tr" };
                logProcess.Create(ex);
                mail.Subject = "E-MİKRO - Bize Ulaşın Formu - HATA";
                mail.Body = ex.Message.ToString();
                mail.SendMail();
            }
        }

        [HttpPost]
        public async Task<ActionResult> ProductRequest(ProductRequestForm model)
        {
            RestApiService restApi = new RestApiService();
            MailHelper mail = new MailHelper();
            LogProcess logProcess = new LogProcess();

            string gclid = Tools.GetQueryStringValueFromUrlReferrer("gclid") ?? Tools.GetQueryStringValueFromRawUrl("gclid");
            string utm_campaign = Tools.GetQueryStringValueFromUrlReferrer("utm_campaign") ?? Tools.GetQueryStringValueFromRawUrl("utm_campaign");
            string utm_medium = Tools.GetQueryStringValueFromUrlReferrer("utm_medium") ?? Tools.GetQueryStringValueFromRawUrl("utm_medium");
            string utm_source = Tools.GetQueryStringValueFromUrlReferrer("utm_source") ?? Tools.GetQueryStringValueFromRawUrl("utm_source");

            try
            {
                model.IPAddress = Tools.GetIpAddress;

                if (String.IsNullOrEmpty(gclid))
                    gclid = Tools.GetCookieValue(Names.Cookie.Gclid);

                if (String.IsNullOrEmpty(utm_campaign))
                    utm_campaign = Tools.GetCookieValue(Names.Cookie.UtmCampaign);

                if (String.IsNullOrEmpty(utm_medium))
                    utm_medium = Tools.GetCookieValue(Names.Cookie.UtmMedium);

                if (String.IsNullOrEmpty(utm_source))
                    utm_source = Tools.GetCookieValue(Names.Cookie.UtmSource);

                Input_RequestForm inpt = new Input_RequestForm
                {
                    firstName = model.FirstName,
                    lastName = model.LastName,
                    email = model.Email,
                    phone = model.Phone,
                    foreignPhoneNumber = model.PhoneCode != "+90" ? model.Phone : "",
                    city = "",
                    company = "company",
                    status = "New",
                    productGroup = model.Product,
                    leadSource = "e-Mikro Demo",
                    gclid = gclid,
                    utmCampaign = utm_campaign,
                    utmMedium = utm_medium,
                    utmSource = utm_source,
                    formNotes = model.Message,
                    mikroMusterisiMi = model.UsingMikroSoftware,
                    izinDurumu = model.DataSharing ? "Izinli" : "Izinsiz"
                };

                if (inpt.foreignPhoneNumber != "")
                {
                    inpt.foreignPhoneNumber = model.PhoneCode.Replace("+", "") + inpt.phone.TrimStart('0').Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                    inpt.phone = "00000000000";
                }
                else
                    inpt.phone = "0" + inpt.phone.TrimStart('0').Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

                Output_DemoRequest resp = restApi.DemoRequestForm(inpt);
                string body = String.Empty;
                using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/Templates/Mail/demo-request.html"), System.Text.Encoding.UTF8))
                    body = sr.ReadToEnd();

                body = body.Replace("@@ad@@", inpt.firstName);
                body = body.Replace("@@soyad@@", inpt.lastName);
                body = body.Replace("@@telefon@@", inpt.phone);
                body = body.Replace("@@yabancitelefon@@", inpt.foreignPhoneNumber);
                body = body.Replace("@@mesaj@@", inpt.formNotes);
                body = body.Replace("@@eposta@@", inpt.email);
                body = body.Replace("@@urun@@", inpt.productGroup);
                body = body.Replace("@@musteri@@", model.UsingMikroSoftware ? "evet" : "hayır");
                body = body.Replace("@@refUrl@@", Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : "-");

                mail.To = new List<string>() { "no-reply@e-mail.mikro.com.tr", "Mert.ALANKAYA@mikro.com.tr", "satis@mikro.com.tr" };
                mail.From = "no-reply@e-mail.mikro.com.tr";
                mail.FromDisplayName = "E-Mikro";
                mail.Body = body;
                mail.Subject = "E-MİKRO - Ürün Talep Formu";
                bool rtn = mail.SendMail();
                if (!rtn)
                    logProcess.WriteLog("Mail Gönderirken hata oluştu <br> " + body);
            }
            catch (Exception ex)
            {
                mail.To = new List<string>() { "emre.gultekin@h.com.tr" };
                logProcess.Create(ex);
                mail.Subject = "E-MİKRO - Ürün Talep Formu - HATA";
                mail.Body = ex.Message.ToString();
                mail.SendMail();
            }

            await ContentfulAPI.Management.AddProductRequestForm(model);
            return Redirect("/tesekkurler");
        }
    }
}