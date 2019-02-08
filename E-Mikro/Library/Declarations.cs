using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace E_Mikro
{
    public struct Const
    {
        public const string FormReturnUrl = "https://www.mikro.com.tr/tesekkurler";
        public const string WSSalesforceUrlToken = "https://login.salesforce.com/services/oauth2/token";
        public const string WSSalesforceUrl = "https://mikro.my.salesforce.com/services/apexrest/MikroLeads/v1";

        public const string WSSalesforceUrlTokenTEST = "https://test.salesforce.com/services/oauth2/token";
        public const string WSSalesforceUrlTEST = "https://mikro--partial.cs86.my.salesforce.com/services/apexrest/MikroLeads/v1";

        public struct API
        {
            public struct Contentful
            {
                public static string SpaceID = WebConfigurationManager.AppSettings["Contentful_SpaceID"];
                public static string DeliveryApiKey = WebConfigurationManager.AppSettings["Contentful_DeliveryApiKey"];
                public static string PreviewAPIKey = WebConfigurationManager.AppSettings["Contentful_ContentPreviewAPIKey"];
                public static string ManagementAPIKey = WebConfigurationManager.AppSettings["Contentful_ManagementPIKey"];

                public struct ContentTypes
                {
                    public static string Page = "pages";
                    public static string News = "news";
                    public static string Menu = "menu";
                    public static string Slider = "sliders";
                    public static string HomePageTripleCTA = "homepageTripleCta";
                    public static string Product = "product";
                    public static string PageCategory = "pageCategories";
                    public static string HeaderLinks = "headerLink";
                    public static string FooterLinks = "footerLink";
                    public static string ContactForm = "contactForm";
                    public static string ProductRequestForm = "productRequestForm";
                    public static string LogoAndImages = "logoAndImages";
                    public static string Video = "video";
                    public static string Campaign = "campaign";
                    public static string PermanentRedirect = "301redirect";
                    public static string FAQ = "faq";
                }
            }
        }
    }
    public struct Names
    {
        public struct WSSettings
        {
            public const string grant_type = "password";
            public const string client_id = "3MVG9HxRZv05HarTuyiQcrETsRw43q_plEZRNkweXDm4KmovEnoWJXMFgISas3mE_Bnyi2rEQ4YaaRbiy2wj.";
            public const string client_secret = "9115095582394842352";
            public const string username = "tolga.dokuzer%40mikro.com.tr";
            public const string password = "MikroAdmin1JkyMWCx2BHrQrsmAoZIUw6rA";
        }
        public struct WSFields
        {
            public const string MessageCode = "/404";
            public const string Message = "/tesekkurler";
        }
        public struct WSOutputMessageCode
        {
            public const string OK = "OK";
            public const string SERVICE_ERROR = "SERVICE_ERROR";
            public const string TokenExpired = "TokenExpired";
            public const string OrderNotFound = "ORDER NOT FOUND";
        }
        public struct Cookie
        {
            public const string Gclid = "gclid";
            public const string UtmCampaign = "utm_campaign";
            public const string UtmMedium = "utm_medium";
            public const string UtmSource = "utm_source";
        }
    }
    public struct Paths
    {
        public struct Views
        {
            public const string Home = "~/Views/Page/Home.cshtml";
            public const string ContactUs = "~/Views/Form/ContactUs.cshtml";
            public const string ProductDetail = "~/Views/Product/Detail.cshtml";
            public const string ProductList = "~/Views/Product/List.cshtml";
            public const string HomeContactUs = "~/Views/Form/Home/HomeContactUs.cshtml";
            public const string RegisterForm = "~/Views/Form/Register.cshtml";
            public const string News = "~/Views/PressRoom/News.cshtml";
            public const string LogoAndImages = "~/Views/PressRoom/LogoAndImages.cshtml";
            public const string NewsMikro = "~/Views/PressRoom/NewsMikro.cshtml";
            public const string Video = "~/Views/Support/Video.cshtml";
            public const string Campaigns = "~/Views/Campaigns/Campaigns.cshtml";
            public const string FAQs = "~/Views/Support/FAQ.cshtml";
            public const string NotFound = "~/Views/Page/NotFound.cshtml";
            public const string Search = "~/Views/Page/Search.cshtml";
            public const string ProductRequestForm = "~/Views/Form/ProductRequestForm.cshtml";

            public struct Layout
            {
                public const string Main = "~/Views/Shared/Layout/Main.cshtml";
                public const string Detail = "~/Views/Shared/Layout/Detail.cshtml";
                public const string DetailWithSidebar = "~/Views/Shared/Layout/DetailWithSidebar.cshtml";
                public const string DetailWithSideMenu = "~/Views/Shared/Layout/DetailWithSideMenu.cshtml";
                public const string Contact = "~/Views/Shared/Layout/Contact.cshtml";
            }

            public struct Partial
            {
                public const string Breadcrumb = "/Views/Shared/Partial/Breadcrumb.cshtml";
                public const string Head = "/Views/Shared/Partial/Head.cshtml";
                public const string Header = "/Views/Shared/Partial/Header.cshtml";
                public const string Footer = "/Views/Shared/Partial/Footer.cshtml";
                public const string ProductSlide = "/Views/Shared/Partial/ProductSlide.cshtml";
                public const string SocialLinks = "/Views/Shared/Partial/SocialLinks.cshtml";
                public const string FooterLinks = "/Views/Shared/Partial/FooterLinks.cshtml";
                public const string Menu = "/Views/Shared/Partial/Menu.cshtml";
                public const string ProductRequestBox = "/Views/Shared/Partial/ProductRequestBox.cshtml";
                public const string ProductRequestForm = "~/Views/Form/Partial/ProductRequestForm.cshtml";
            }
        }
    }
}