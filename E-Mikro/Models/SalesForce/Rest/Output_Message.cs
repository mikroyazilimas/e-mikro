using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace E_Mikro.Models
{
    public class Output_Message
    {        
        [DataMember]
        public string MessageCode { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public bool isSuccess { get; set; }
    }
}