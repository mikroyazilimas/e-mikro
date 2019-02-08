using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace E_Mikro.Models
{
    public class Input_RequestForm
    {
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string foreignPhoneNumber { get; set; }
        [DataMember]
        public string company { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string leadSource { get; set; }
        [DataMember]
        public string formNotes { get; set; }
        [DataMember]
        public string gclid { get; set; }
        [DataMember]
        public string utmSource { get; set; }
        [DataMember]
        public string utmMedium { get; set; }
        [DataMember]
        public string utmCampaign { get; set; }
        [DataMember]
        public string foundationYear { get; set; }
        [DataMember]
        public string numberOfEmployees { get; set; }
        [DataMember]
        public string currentSoftware { get; set; }
        [DataMember]
        public string productGroup { get; set; }
        [DataMember]
        public string city { get; set; }

        [DataMember]
        public bool mikroMusterisiMi { get; set; }

        [DataMember]
        public string numberOfUser { get; set; }
        [DataMember]
        public string sector { get; set; }
        [DataMember]
        public string currentSituation { get; set; }

        [DataMember]
        public string izinDurumu { get; set; }
    }
}