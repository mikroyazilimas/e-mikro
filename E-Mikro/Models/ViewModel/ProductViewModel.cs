using System;
using System.Linq;
using System.Web;
using E_Mikro.Models.Contentful;
using System.Collections.Generic;

namespace E_Mikro.Models.ViewModel
{
    public class ProductViewModel
    {
        public List<Product> ProductList { get; set; }
        public Product ProductDetail { get; set; }
    }
}