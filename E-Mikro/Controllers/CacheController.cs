using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Mikro.Controllers
{
    public class CacheController : Base
    {
        [HttpGet]
        public ActionResult Clear()
        {
            Tools.ClearCache();
            return Redirect("/");
        } 
    }
}