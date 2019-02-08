using System;
using System.Linq;
using System.Web;
using E_Mikro.Models.Contentful;
using System.Collections.Generic;

namespace E_Mikro.Models.ViewModel
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.ContactForm = new ContactForm();
        }
        public List<Slider> Slider { get; set; }
        public List<Product> Products { get; set; }
        public List<TripleCTA> TripleCTA { get; set; }
        public ContactForm ContactForm { get; set; }
        public Page Page { get; set; }
    }
}