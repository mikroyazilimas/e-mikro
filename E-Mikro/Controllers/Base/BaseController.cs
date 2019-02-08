using E_Mikro.Library;
using E_Mikro.Library.Contentful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Mikro.Controllers
{
    public class Base : Controller
    {
        public C C = new C();
        public ContentfulAPI ContentfulAPI = new ContentfulAPI();
    }
}