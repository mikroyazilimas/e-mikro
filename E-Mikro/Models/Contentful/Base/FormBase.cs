using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class FormBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PhoneCode { get; set; }
        public string Email { get; set; }
        public string IPAddress { get; set; }
        public bool DataSharing { get; set; }
        public string Message { get; set; }
    }
}