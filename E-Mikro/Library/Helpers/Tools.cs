using E_Mikro.Models;
using E_Mikro.Models.Contentful;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;


namespace E_Mikro
{
    public class Tools
    {
        public static void ClearCache()
        {
            foreach (DictionaryEntry dEntry in HttpContext.Current.Cache)
            {
                HttpContext.Current.Cache.Remove(dEntry.Key.ToString());
            }
        }

        public static string GetQueryStringValueFromRawUrl(string queryStringKey)
        {
            var currentUri = new Uri(HttpContext.Current.Request.Url.Scheme + "://" +
                HttpContext.Current.Request.Url.Authority +
                HttpContext.Current.Request.RawUrl);
            var queryStringCollection = HttpUtility.ParseQueryString((currentUri).Query);
            return queryStringCollection.Get(queryStringKey);
        }

        public static string GetQueryStringValueFromUrlReferrer(string queryStringKey)
        {
            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                var currentUri = new Uri(HttpContext.Current.Request.UrlReferrer.ToString());
                var queryStringCollection = HttpUtility.ParseQueryString((currentUri).Query);
                return queryStringCollection.Get(queryStringKey);
            }
            else
            {
                return "";
            }
        }

        public static T HttpRequest<T>(WebRequest request)
        {
            string responseStr = "";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseStr = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception)
            { }
            JavaScriptSerializer js = new JavaScriptSerializer();
            T responseT = js.Deserialize<T>(responseStr);
            return responseT;
        }
        public static bool IsMainPage
        {
            get
            {
                return HttpContext.Current.Request.RawUrl.TrimEnd('/') == "" || HttpContext.Current.Request.RawUrl == "/anasayfa";
            }
        }
        public static Breadcrumb SetBreadcrumb(Page Page, List<Menu> Menu)
        {
            var breadcrumb = new Breadcrumb() { CurrentPageName = Page.Title };
            var foundMenu = Menu.FirstOrDefault(p => p.Pages != null && p.Pages.FindIndex(pp => pp.Url == Page.Url) > -1);
            if (foundMenu != null)
                breadcrumb.Nodes.Add(new Navigation { Name = foundMenu.Title, Url = foundMenu.Link });
            return breadcrumb;
        }

        public static Breadcrumb SetProductBreadcrumb(Product Product, Menu Menu)
        {
            var breadcrumb = new Breadcrumb() { CurrentPageName = Product.Name };
            breadcrumb.Nodes.Add(new Navigation { Name = Menu.Title, Url = Menu.Link });
            return breadcrumb;
        }

        public static void DeleteCookie(string cookieName)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = "";
            cookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void LogWrite(string filename, string logMessage)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("/App_Data/CustomLogs");

                using (StreamWriter w = File.AppendText(path + "\\" + filename))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            { }
        }

        private static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nDate : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  ");
                txtWriter.WriteLine("{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            { }
        }

        public static string FormatPhoneNumber(string phone)
        {
            if (!String.IsNullOrEmpty(phone))
            {
                try
                {
                    phone = phone.TrimStart('0');
                    phone = string.Format("{0:(###) ### ## ##}", long.Parse(phone));
                }
                catch (Exception)
                { }
            }
            return phone;
        }

        public static string ReadHtml(string htmlName)
        {
            return File.ReadAllText(HttpContext.Current.Server.MapPath(string.Format(@"~\Content\Template\{0}.html", htmlName)));
        }

        #region RegularizeNumber
        public static string RegularizeNumber(string Number)
        {
            string regularizedNumber = string.Empty;
            string regularizedNumberTurn = string.Empty;
            string numberString = Number;
            try
            {
                byte count = 0;
                for (int i = numberString.Length; i > 0; i--)
                {
                    count++;
                    regularizedNumber += numberString[i - 1].ToString();

                    if (count % 3 == 0 && i - 1 > 0)
                        regularizedNumber += ".";
                }
            }
            catch (Exception)
            {
                regularizedNumber = string.Empty;
            }

            for (int i = regularizedNumber.Length - 1; i > -1; i--)
                regularizedNumberTurn += regularizedNumber[i];

            return regularizedNumberTurn;
        }
        #endregion

        #region GetResourceKeyValue
        public static string GetResourceKeyValue(string Key, string Resource = "Global")
        {
            try
            {
                return HttpContext.GetGlobalResourceObject(Resource, Key).ToString().Replace("<br />", System.Environment.NewLine);
            }
            catch (Exception)
            {
                return Key;
            }
        }
        #endregion

        #region SetCookie
        public static void SetCookie(string cookieName, string value, DateTime expireDate)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = value;
            cookie.Expires = expireDate;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        #endregion

        #region GetImageExtension
        public static string GetImageExtension(Image img)
        {
            if (img.RawFormat.Equals(ImageFormat.Jpeg))
                return "jpg";
            else if (img.RawFormat.Equals(ImageFormat.Png))
                return "png";
            else if (img.RawFormat.Equals(ImageFormat.Bmp))
                return "bmp";
            else
                return "jpg";
        }
        #endregion

        #region EncodeNumber
        public static int GenerateUniqueNumber()
        {
            Random r = new Random();
            return r.Next(1, 9999);
        }
        #endregion

        #region ToFriendlyUrl
        public static string ToFriendlyUrl(string value)
        {
            value = value.ToLower().Replace("ğ", "g").Replace("ş", "s").Replace("ı", "i").Replace("ö", "o").Replace("ü", "u").Replace("ç", "c").Replace("!", "");
            return Regex.Replace(value, @"[^A-Za-z0-9_\.~]+", "-");
        }
        #endregion

        #region ToEnglishChars
        public static string ToEnglishChars(string Message)
        {
            return Message.Replace("İ", "I").Replace("Ğ", "G").Replace("Ş", "S").Replace("Ö", "O").Replace("Ç", "C").Replace("Ü", "U")
                          .Replace("ı", "i").Replace("ğ", "g").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c").Replace("ü", "u");
        }
        #endregion

        #region ParseYoutubeID
        public static string ParseYoutubeID(string URL)
        {
            try
            {
                var url = URL;
                var uri = new Uri(url);
                var query = HttpUtility.ParseQueryString(uri.Query);
                var videoId = string.Empty;
                if (query.AllKeys.Contains("v"))
                    videoId = query["v"];
                else
                    videoId = uri.Segments.Last();

                return videoId;
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion

        #region IsCurrentPage
        public static bool IsCurrentPage(string Page)
        {
            return HttpContext.Current.Request.Url.AbsoluteUri.Contains(Page);
        }
        #endregion     

        #region ToHttpPostedFile
        public static HttpPostedFile ToHttpPostedFile(HttpPostedFileBase fileBase)
        {
            var constructorInfo = typeof(HttpPostedFile).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
            return (HttpPostedFile)constructorInfo.Invoke(new object[] { fileBase.FileName, fileBase.ContentType, fileBase.InputStream });
        }
        #endregion

        #region GetCookieValue
        public static string GetCookieValue(string cookieName)
        {
            string retVal = string.Empty;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
                retVal = cookie.Value;
            return retVal;
        }
        #endregion

        public static bool IsMobileBrowser
        {
            get
            {
                string userAgent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
                Regex OS = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                Regex device = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                string device_info = string.Empty;
                if (OS.IsMatch(userAgent))
                    device_info = OS.Match(userAgent).Groups[0].Value;
                if (device.IsMatch(userAgent.Substring(0, 4)))
                    device_info += device.Match(userAgent).Groups[0].Value;
                return !string.IsNullOrEmpty(device_info);
            }
        }

        #region GetIpAddress
        public static string GetIpAddress
        {
            get
            {
                string ipAddress;
                try { ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; }
                catch { ipAddress = "0"; }
                return ipAddress;
            }
        }
        #endregion

        #region CapitalizeWords
        public static string CapitalizeWords(string Words)
        {
            var culture = new CultureInfo("tr-TR");
            return culture.TextInfo.ToTitleCase(Words.ToLower(culture));
        }
        #endregion

        #region ConvertToJSON
        public static string ConvertToJSON(object data)
        {
            string retVal = string.Empty;
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            try
            {
                retVal = serializer.Serialize(data);
            }
            catch (Exception)
            { }

            return retVal;
        }
        #endregion

        #region EncodeBase64
        public static string Base64Encode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region DecodeBase64
        public static string DecodeBase64(string data)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region JSONToObject
        public static T JSONToObject<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            try
            {
                return serializer.Deserialize<T>(json);
            }
            catch (Exception)
            { }

            return default(T);
        }
        #endregion

        #region IllegalCharacters
        public static List<string> IllegalCharacters
        {
            get
            {
                List<string> illegalCharacters = new List<string>();
                #region Characters
                illegalCharacters.Add("\"");
                illegalCharacters.Add("'");
                illegalCharacters.Add("=");
                illegalCharacters.Add("_");
                illegalCharacters.Add("+");
                #endregion
                return illegalCharacters;
            }
        }
        #endregion

        #region GetCryptoKey
        private static byte[] GetCryptoKey()
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            string plainKey = "rastkoisajev2310982josipasenera153";
            byte[] encodedKey = unicodeEncoding.GetBytes(plainKey);

            // Prepares 192 bit key
            byte[] preparedKey = new byte[24];
            Array.Copy(encodedKey, preparedKey, 24);

            return preparedKey;
        }
        #endregion

        #region EncryptData
        public static string EncryptData(string toEncrypt, bool useHashing = false)
        {
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = GetCryptoKey();
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();


            string encrtyptedText = Convert.ToBase64String(resultArray, 0, resultArray.Length);

            for (int i = 0; i < IllegalCharacters.Count; i++)
                encrtyptedText = encrtyptedText.Replace(IllegalCharacters[i], "eg-" + i.ToString());

            return encrtyptedText;
        }
        #endregion

        #region EncryptData
        public static string EncryptData(int toEncrypt, bool useHashing = false)
        {
            string toEncryptStr = toEncrypt.ToString();
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncryptStr);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = GetCryptoKey();
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            string encrtyptedText = Convert.ToBase64String(resultArray, 0, resultArray.Length);

            for (int i = 0; i < IllegalCharacters.Count; i++)
                encrtyptedText = encrtyptedText.Replace(IllegalCharacters[i], "eg-" + i.ToString());

            return encrtyptedText;
        }
        #endregion

        #region DecryptData
        public static string DecryptData(string cipherString, bool useHashing = false)
        {
            for (int i = 0; i < IllegalCharacters.Count; i++)
                cipherString = cipherString.Replace("eg-" + i.ToString(), IllegalCharacters[i]);

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = GetCryptoKey();
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion

        public static string GetDomInnerText(string input)
        {
            string pattern = "\\<.*?>";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(input, replacement);
            return result;
        }
    }
}