using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class Slider : ContentfulBaseModel
    {
        public string Name { get; set; }
        public Media Image { get; set; }
        public Media MobileImage { get; set; }
        public string Link { get; set; }
        public string LinkTarget { get; set; }
        public string Type { get; set; }
        public string SpotText { get; set; }
        public int Order { get; set; }
    }
}