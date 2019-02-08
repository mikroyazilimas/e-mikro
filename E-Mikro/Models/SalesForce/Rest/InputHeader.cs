using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models
{
    public class InputHeader
    {
        public bool Token { get; set; }
        public string Authorization { get; set; }
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

//request.AddHeader("Authorization", Authorization);
//                }
//                else
//                {
//                    request.AddHeader("grant_type", grant_type);
//                    request.AddHeader("client_id", client_id);
//                    request.AddHeader("client_secret", client_secret);
//                    request.AddHeader("username", username);
//                    request.AddHeader("password", password);