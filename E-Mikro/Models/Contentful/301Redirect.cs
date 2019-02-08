using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class PermanentRedirect : ContentfulBaseModel
    {
        public string FromUrl { get; set; }
        public string ToUrl { get; set; }
    }
}