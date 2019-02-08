using E_Mikro.Library.Contentful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_Mikro
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpException)
            {
                if (((HttpException)(ex)).GetHttpCode() == 404)
                {
                    ContentfulAPI ContentfulAPI = new ContentfulAPI();
                    var permanentRedirects = Task.Run(async () => await ContentfulAPI.Delivery.Get301Redirects()).Result;
                    var foundRedirect = permanentRedirects.FirstOrDefault(p => p.FromUrl.ToLower().Contains(Request.RawUrl.ToLower()));
                    if (foundRedirect != null)
                    {
                        Response.StatusCode = 301;
                        Response.Redirect(foundRedirect.ToUrl);
                    }
                    else
                        HttpContext.Current.Response.Redirect("/404");
                }
            }
        }
    }
}
