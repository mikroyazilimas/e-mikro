using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class Campaign
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Media Image { get; set; }
    }
}