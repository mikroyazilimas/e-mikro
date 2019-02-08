using System;
using System.Web;
using E_Mikro.Models;
using E_Mikro.Models.Contentful;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core.Search;
using System.Net;

namespace E_Mikro.Library.Contentful
{
    public partial class ContentfulAPI
    {
        public partial class DeliveryApi
        {
            public async Task<List<Menu>> GetMenu()
            {
                IEnumerable<Menu> response = null;
                var cachedData = C.Caching<Menu>(C.Names.Menu, null);
                if (cachedData == null)
                {
                    var builder = QueryBuilder<Menu>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.Menu);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.OrderBy(p => p.Order).ToList();
                        C.Caching<Menu>(C.Names.Menu, data);
                        return data;
                    }
                    else
                        return null;
                }
                else
                    return cachedData;
            }

            public async Task<List<Navigation>> GetNavigationLinks(NavigationType Type)
            {
                IEnumerable<Navigation> response = null;
                var cachedData = C.Caching<Navigation>(C.Names.Navigation + Type.ToString(), null);
                if (cachedData == null)
                {
                    string contentTypeId = Type == NavigationType.Header ? Const.API.Contentful.ContentTypes.HeaderLinks : Const.API.Contentful.ContentTypes.FooterLinks;
                    var builder = QueryBuilder<Navigation>.New.ContentTypeIs(contentTypeId);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.OrderBy(p => p.Order).ToList();
                        C.Caching<Navigation>(C.Names.Navigation + Type.ToString(), data);
                        return data;
                    }
                    else
                        return null;
                }
                else
                    return cachedData;
            }
        }
    }
}