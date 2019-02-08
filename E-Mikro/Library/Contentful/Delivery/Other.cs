using Contentful.Core.Search;
using E_Mikro.Models;
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
            public async Task<List<TripleCTA>> GetHomePageTripleCTA()
            {
                IEnumerable<TripleCTA> response = null;
                var cachedData = C.Caching<TripleCTA>(C.Names.TripleCTA, null);
                if (cachedData == null)
                {
                    var builder = QueryBuilder<TripleCTA>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.HomePageTripleCTA);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.OrderBy(p => p.Order).Take(3).ToList();
                        C.Caching<TripleCTA>(C.Names.TripleCTA, data);
                        return data;
                    }
                    else
                        return null;
                }
                else
                    return cachedData;
            }

            public async Task<List<Video>> GetVideos()
            {
                IEnumerable<Video> response = null;
                var cachedData = C.Caching<Video>(C.Names.Video, null);
                if (cachedData == null)
                {
                    var builder = QueryBuilder<Video>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.Video);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.OrderBy(p => p.Order).ToList();
                        C.Caching<Menu>(C.Names.Video, data);
                        return data;
                    }
                    else
                        return null;
                }
                return cachedData;
            }

            public async Task<List<Campaign>> GetCampaigns()
            {
                IEnumerable<Campaign> response = null;
                var cachedData = C.Caching<Campaign>(C.Names.Campaign, null);
                if (cachedData == null)
                {
                    var builder = QueryBuilder<Campaign>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.Campaign);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.OrderByDescending(p => p.Date).ToList();
                        C.Caching<Menu>(C.Names.Campaign, data);
                        return data;
                    }
                    else
                        return null;
                }
                else
                    return cachedData;
            }

            public async Task<List<PermanentRedirect>> Get301Redirects()
            {
                IEnumerable<PermanentRedirect> response = null;
                var cachedData = C.Caching<PermanentRedirect>(C.Names.PermanentRedirect, null);
                if (cachedData == null)
                {
                    var builder = QueryBuilder<PermanentRedirect>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.PermanentRedirect);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.ToList();
                        C.Caching<Menu>(C.Names.PermanentRedirect, data);
                        return data;
                    }
                    else
                        return null;
                }
                else
                    return cachedData;
            }

            public async Task<List<FAQ>> GetFAQs()
            {
                IEnumerable<FAQ> response = null;
                var cachedData = C.Caching<FAQ>(C.Names.FAQ, null);
                if (cachedData == null)
                {
                    var builder = QueryBuilder<FAQ>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.FAQ);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.OrderBy(p => p.Order).ToList();
                        C.Caching<Menu>(C.Names.FAQ, data);
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