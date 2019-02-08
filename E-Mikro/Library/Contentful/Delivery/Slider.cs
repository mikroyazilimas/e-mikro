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
        public partial class DeliveryApi : Base
        {
            public async Task<List<Slider>> GetHomePageSlider()
            {
                IEnumerable<Slider> response = null;
                var cachedData = C.Caching<Slider>(C.Names.Slider, null);
                if (cachedData == null)
                {
                    var builder = QueryBuilder<Slider>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.Slider);
                    response = await Client.GetEntries(builder);
                    if (response != null)
                    {
                        var data = response.OrderBy(p => p.Order).ToList();
                        C.Caching<Slider>(C.Names.Slider, data);
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