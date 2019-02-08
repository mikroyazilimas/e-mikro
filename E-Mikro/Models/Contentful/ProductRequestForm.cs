using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace E_Mikro.Models.Contentful
{
    public class ProductRequestForm : FormBase
    {
        public string Product { get; set; }
        public bool UsingMikroSoftware { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public bool IsOnlyMobile { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public bool IsPage { get; set; }
    }
}