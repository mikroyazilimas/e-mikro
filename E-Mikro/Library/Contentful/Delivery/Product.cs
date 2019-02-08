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
            public async Task<List<Product>> GetProducts()
            {
                IEnumerable<Product> response = null;
                var cachedData = C.Caching<Product>(C.Names.Products, null);
                if (cachedData == null)
                {
                    var builder = QueryBuilder<Product>.New.ContentTypeIs(Const.API.Contentful.ContentTypes.Product);
                    response = await Client.GetEntries(builder);

                    if (response != null)
                    {
                        var data = response.OrderBy(p => p.Order).ToList();
                        C.Caching<Product>(C.Names.Products, data);
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