using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class Product : ContentfulBaseModel
    {
        public Product()
        {
            Summary = "";
            TabContents = "";
            Description = "";
            Features = "";
        }

        public string Name { get; set; }
        public string SalesForceName { get; set; }
        public string Summary { get; set; }
        public string Features { get; set; }
        public string TabContents { get; set; }
        public string Description { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public Media Logo { get; set; }
        public Media DetailPageLogo { get; set; }
        public Media Video { get; set; }
        public int Order { get; set; }
        public string ExternalLink { get; set; }
        public string Url { get; set; }
    }
}