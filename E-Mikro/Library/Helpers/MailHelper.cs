using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Configuration;
using System.Globalization;
using System.Text;

namespace E_Mikro.Library
{
    public class MailHelper
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromDisplayName { get; set; }

        public bool SendMail()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "mail.e-mail.mikro.com.tr";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = false;
                smtpClient.Credentials = new NetworkCredential("no-reply@e-mail.mikro.com.tr", "no**+1267mk");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("no-reply@e-mail.mikro.com.tr");

                if (To != null)
                    foreach (string email in To)
                        mail.To.Add(new MailAddress(email));

                if (CC != null)
                    foreach (string email in CC)
                        mail.CC.Add(new MailAddress(email));

                if (Bcc != null)
                    foreach (string email in Bcc)
                        mail.Bcc.Add(new MailAddress(email));

                mail.From = new MailAddress(From, FromDisplayName);
                mail.Subject = Subject;
                mail.IsBodyHtml = true;
                mail.Body = Body;
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}