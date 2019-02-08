using Contentful.Core.Models;
using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class Page : ContentfulBaseModel
    {
        public string Title { get; set; }
        public PageTemplate Template { get; set; }
        public string Layout
        {
            get
            {
                if (Template == PageTemplate.Main)
                    return Paths.Views.Layout.Main;

                if (Template == PageTemplate.Detail)
                    return Paths.Views.Layout.Detail;

                if (Template == PageTemplate.DetailWithSidebar)
                    return Paths.Views.Layout.DetailWithSidebar;

                if (Template == PageTemplate.Contact)
                    return Paths.Views.Layout.Contact;

                if (Template == PageTemplate.DetailWithSideMenu)
                    return Paths.Views.Layout.DetailWithSideMenu;

                else
                    return Paths.Views.Layout.Main;
            }
        }
        public PageComponent StaticPageComponent { get; set; }
        public string SpotText { get; set; }
        public string SpotTextRight { get; set; }
        public string Content { get; set; }
        public ContentfulKeyValue Category { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string Url { get; set; }
        public bool IncludeBreadcrumb { get; set; }
        public bool IsMainpage { get; set; }
        public bool IsRedirectPage { get; set; }
        public string RedirectUrl { get; set; }
        public int StatusCode { get; set; }

        public object Data { get; set; }
        public ContactForm ContactForm { get; set; }
    }
}