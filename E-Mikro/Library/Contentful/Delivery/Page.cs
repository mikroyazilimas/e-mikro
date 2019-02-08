using Contentful.Core.Search;
using E_Mikro.Models.Contentful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace E_Mikro.Library.Contentful
{
    public partial class ContentfulAPI
    {
        public partial class DeliveryApi
        {
            public async Task<Page> GetPage(string Url)
            {
                IEnumerable<Page> response = null;
                QueryBuilder<Page> builder = QueryBuilder<Page>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.Page);

                if (!String.IsNullOrEmpty(Url))
                    builder = builder.FieldEquals("fields.url", Url);
                else
                    builder = builder.FieldEquals("fields.isMainpage", "1");

                response = await Client.GetEntries(builder);

                if (response != null)
                    return response.FirstOrDefault();
                else
                    return null;
            }

            public async Task<List<Page>> GetAllPages()
            {
                IEnumerable<Page> response = null;
                var cachedData = C.Caching<Page>(C.Names.Pages, null);
                if (cachedData == null)
                {
                    QueryBuilder<Page> builder = QueryBuilder<Page>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.Page);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.ToList();
                        C.Caching<Page>(C.Names.Pages, data);
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