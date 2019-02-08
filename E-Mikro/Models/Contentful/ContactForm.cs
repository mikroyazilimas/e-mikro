using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class ContactForm : FormBase
    {
        public string Subject { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
    }
}