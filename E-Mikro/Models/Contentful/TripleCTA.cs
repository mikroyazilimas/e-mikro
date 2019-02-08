using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class TripleCTA : ContentfulBaseModel
    {
        public string Name { get; set; }
        public Media Logo { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
    }
}