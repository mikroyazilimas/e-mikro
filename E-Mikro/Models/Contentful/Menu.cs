using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class Menu
    {
        public string Title { get; set; }
        public List<Page> Pages { get; set; }
        public List<string> WebLinks { get; set; }
        public string Link { get; set; }
        public bool IsHaveProducts { get; set; }
        public int Order { get; set; }
    }
}