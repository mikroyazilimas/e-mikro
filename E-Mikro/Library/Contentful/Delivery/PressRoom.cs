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
            public async Task<List<News>> GetNews(NewsType Type)
            {
                IEnumerable<News> response = null;
                var cachedData = C.Caching<News>(C.Names.News, null);
                if (cachedData == null)
                {
                    QueryBuilder<News> builder = QueryBuilder<News>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.News).FieldEquals("fields.type", Type.ToString());
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.OrderByDescending(p => p.Date).ToList();
                        C.Caching<Menu>(C.Names.News, data);
                        return data;
                    }
                    else
                        return null;
                }
                else
                    return cachedData;
            }

            public async Task<List<LogoAndImage>> GetLogoAndImages()
            {
                IEnumerable<LogoAndImage> response = null;
                var cachedData = C.Caching<LogoAndImage>(C.Names.LogoAndImages, null);
                if (cachedData == null)
                {
                    QueryBuilder<LogoAndImage> builder = QueryBuilder<LogoAndImage>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.LogoAndImages);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.OrderBy(p => p.Order).ToList();
                        C.Caching<Menu>(C.Names.LogoAndImages, data);
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