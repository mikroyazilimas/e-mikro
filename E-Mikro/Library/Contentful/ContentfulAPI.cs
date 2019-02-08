using Contentful.Core;
using Contentful.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace E_Mikro.Library.Contentful
{
    public partial class ContentfulAPI
    {
        public ManagementApi Management { get; set; }
        public DeliveryApi Delivery { get; set; }
        private static string SpaceId = Const.API.Contentful.SpaceID;
        private static string DeliveryAPIKey = Const.API.Contentful.DeliveryApiKey;
        private static string PreviewAPIKey = Const.API.Contentful.PreviewAPIKey;
        private static string ManagementAPIKey = Const.API.Contentful.ManagementAPIKey;
        private static string Environment = "master";

        public ContentfulAPI()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            this.Management = new ManagementApi();
            this.Delivery = new DeliveryApi();
        }

        public partial class ManagementApi
        {
            private ContentfulManagementClient Client
            {
                get
                {
                    var httpClient = new HttpClient();
                    return new ContentfulManagementClient(httpClient, new ContentfulOptions
                    {
                        SpaceId = SpaceId,
                        ManagementApiKey = ManagementAPIKey,
                        Environment = Environment
                    });
                }
            }
        }

        public partial class DeliveryApi
        {
            private ContentfulClient Client
            {
                get
                {
                    var httpClient = new HttpClient();
                    return new ContentfulClient(httpClient, new ContentfulOptions
                    {
                        SpaceId = SpaceId,
                        DeliveryApiKey = DeliveryAPIKey,
                        Environment = Environment
                    });
                }
            }
        }
    }
}