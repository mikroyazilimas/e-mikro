using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class LogoAndImage : ContentfulBaseModel
    {
        public Media Image { get; set; }
        public int Order { get; set; }
    }
}