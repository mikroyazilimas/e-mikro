using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class FAQ
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
    }
}