using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class News : ContentfulBaseModel
    {
        public string Title { get; set; }
        public string SummaryText { get; set; }
        public DateTime Date { get; set; }
        public NewsType Type { get; set; }
        public Media DetailImage { get; set; }
    }
}