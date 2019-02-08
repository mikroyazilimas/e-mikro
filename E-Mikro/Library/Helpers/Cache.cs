using E_Mikro.Models.Contentful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace E_Mikro.Library
{
    public class C
    {
        public C()
        { }

        public static int timeout = 20;
        public struct Names
        {
            public const string Slider = "Slider";
            public const string Products = "Products";
            public const string Menu = "Menu";
            public const string Navigation = "Navigation";
            public const string TripleCTA = "TripleCTA";
            public const string Video = "Video";
            public const string Campaign = "Campaign";
            public const string PermanentRedirect = "PermanentRedirect";
            public const string FAQ = "FAQ";
            public const string News = "News";
            public const string LogoAndImages = "LogoAndImages";
            public const string Pages = "Pages";
        }
        public List<T> Caching<T>(string CacheName, object Object)
        {
            Cache cache = HttpRuntime.Cache;
            var source = cache[CacheName];
            if (source != null)
                return source as List<T>;
            else if (Object != null)
                cache.Insert(CacheName, Object, null, DateTime.Now.AddMinutes(timeout), Cache.NoSlidingExpiration);

            return null;
        }
    }
}