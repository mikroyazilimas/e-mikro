using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models
{
    public class Navigation
    {
        public string Name { get; set; }
        public Media Icon { get; set; }
        public int Order { get; set; }
        public string LinkTarget { get; set; }
        public string Url { get; set; }
    }
}