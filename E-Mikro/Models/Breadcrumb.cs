using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models
{
    public class Breadcrumb
    {
        public Breadcrumb()
        {
            this.Nodes = new List<Navigation>
            {
                new Navigation { Name = "Anasayfa", Url = "/" }
            };
        }
        public string CurrentPageName { get; set; }
        public List<Navigation> Nodes { get; set; }
    }
}