using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace E_Mikro.Models
{
    public class Input_Token
    {
        [DataMember]
        public string GrantType { get; set; }
        [DataMember]
        public string ClientId { get; set; }
        [DataMember]
        public string ClientSecret { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}