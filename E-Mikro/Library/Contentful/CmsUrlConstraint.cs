using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using E_Mikro.Library.Contentful;
using E_Mikro.Models;
using E_Mikro.Models.Contentful;
using E_Mikro.Models.ViewModel;

namespace E_Mikro.Library
{
    public class CmsUrlConstraint : IRouteConstraint
    {
        public C C = new C();
        public ContentfulAPI ContentfulAPI = new ContentfulAPI();
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values[parameterName] != null)
            {
                var permalink = values[parameterName].ToString();
                var page = Task.Run(async () => await ContentfulAPI.Delivery.GetPage(permalink)).Result;
                if (page == null)
                {
                    var products = Task.Run(async () => await ContentfulAPI.Delivery.GetProducts()).Result;
                    var productPage = products.FirstOrDefault(p => p.Url == permalink);
                    return productPage != null;
                }
                return page != null;
            }
            return false;
        }
    }
}