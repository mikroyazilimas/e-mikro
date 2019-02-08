using System;
using System.Web;
using E_Mikro.Models.Contentful;
using System.Threading.Tasks;
using Contentful.Core.Models;

namespace E_Mikro.Library.Contentful
{
    public partial class ContentfulAPI
    {
        public partial class ManagementApi
        {
            public async Task<Entry<dynamic>> AddContactForm(ContactForm item)
            {
                item.IPAddress = Tools.GetIpAddress;
                return await Client.CreateEntryForLocale(item, Guid.NewGuid().ToString(), Const.API.Contentful.ContentTypes.ContactForm, "tr-TR");
            }

            public async Task<Entry<dynamic>> AddProductRequestForm(ProductRequestForm item)
            {
                item.IPAddress = Tools.GetIpAddress;
                return await Client.CreateEntryForLocale(item, Guid.NewGuid().ToString(), Const.API.Contentful.ContentTypes.ProductRequestForm, "tr-TR");
            }
        }
    }
}