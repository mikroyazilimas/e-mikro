using E_Mikro.Library.Contentful;
using E_Mikro.Models;
using E_Mikro.Models.Contentful;
using E_Mikro.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace E_Mikro.Controllers
{
    public class PageController : Base
    {
        public PageController()
        { }

        public async Task<ActionResult> Home(Page Page)
        {
            HomeViewModel model = new HomeViewModel
            {
                Slider = await ContentfulAPI.Delivery.GetHomePageSlider(),
                Products = await ContentfulAPI.Delivery.GetProducts(),
                TripleCTA = await ContentfulAPI.Delivery.GetHomePageTripleCTA(),
                Page = Page
            };

            return View(Paths.Views.Home, model);
        }

        public ActionResult Product(Product Product)
        {
            ProductViewModel model = new ProductViewModel
            {
                ProductDetail = Product,
                ProductList = ViewBag.Products
            };

            return View(Paths.Views.ProductDetail, model);
        }

        public async Task<ActionResult> StaticPage(Page Page)
        {
            string viewPath = string.Empty;
            switch (Page.StaticPageComponent)
            {
                case PageComponent.ContactForm:
                    viewPath = Paths.Views.ContactUs;
                    break;
                case PageComponent.ProductList:
                    Page.Data = ViewBag.Products;
                    viewPath = Paths.Views.ProductList;
                    break;
                case PageComponent.RegisterForm:
                    viewPath = Paths.Views.RegisterForm;
                    break;
                case PageComponent.Search:
                    Page.Data = await SearchResults();
                    viewPath = Paths.Views.Search;
                    break;
                case PageComponent.NewsMikro:
                    Page.Data = await ContentfulAPI.Delivery.GetNews(NewsType.BasindaMikro);
                    viewPath = Paths.Views.NewsMikro;
                    break;
                case PageComponent.News:
                    Page.Data = await ContentfulAPI.Delivery.GetNews(NewsType.BasinBulteni);
                    viewPath = Paths.Views.News;
                    break;
                case PageComponent.LogoAndImages:
                    Page.Data = await ContentfulAPI.Delivery.GetLogoAndImages();
                    viewPath = Paths.Views.LogoAndImages;
                    break;
                case PageComponent.Video:
                    Page.Data = await ContentfulAPI.Delivery.GetVideos();
                    viewPath = Paths.Views.Video;
                    break;
                case PageComponent.Campaigns:
                    Page.Data = await ContentfulAPI.Delivery.GetCampaigns();
                    viewPath = Paths.Views.Campaigns;
                    break;
                case PageComponent.FAQ:
                    Page.Data = await ContentfulAPI.Delivery.GetFAQs();
                    viewPath = Paths.Views.FAQs;
                    break;
                case PageComponent.ProductRequestForm:
                    viewPath = Paths.Views.ProductRequestForm;
                    break;
                default:
                    Response.StatusCode = 404;
                    return View(Paths.Views.NotFound);
            }

            return View(viewPath, Page);
        }

        public async Task<ActionResult> Contentful(string Url)
        {
            if (Url == "404")
            {
                var permanentRedirects = await ContentfulAPI.Delivery.Get301Redirects();
                var foundRedirect = permanentRedirects.FirstOrDefault(p => p.FromUrl.ToLower().Contains(Request.RawUrl.ToLower()));
                if (foundRedirect != null)
                {
                    Response.Status = "301 Moved Permanently";
                    Response.StatusCode = 301;
                    string redirectUrl = string.Format("{0}://{1}/{2}", Request.Url.Scheme, Request.Url.Host, foundRedirect.ToUrl.TrimStart('/'));
                    Response.AddHeader("Location", redirectUrl);
                    return null;
                }
            }

            ViewBag.Menu = await ContentfulAPI.Delivery.GetMenu();
            ViewBag.Header = await ContentfulAPI.Delivery.GetNavigationLinks(NavigationType.Header);
            ViewBag.Footer = await ContentfulAPI.Delivery.GetNavigationLinks(NavigationType.Footer);
            ViewBag.Products = await ContentfulAPI.Delivery.GetProducts();
            ViewBag.IncludeBreadcrumb = false;

            var page = await ContentfulAPI.Delivery.GetPage(Url);
            if (page != null)
            {
                if (page.IsRedirectPage)
                    Response.Redirect(page.RedirectUrl, true);

                ViewBag.Title = String.IsNullOrEmpty(page.MetaTitle) ? page.Title : page.MetaTitle;
                ViewBag.MetaDescription = page.MetaDescription;
                ViewBag.MetaKeywords = page.MetaKeywords;
                ViewBag.IncludeBreadcrumb = page.IncludeBreadcrumb;
                ViewBag.IsSplitSpotText = !String.IsNullOrEmpty(page.SpotTextRight);
                if (page.StatusCode != 0)
                    Response.StatusCode = page.StatusCode;

                if (page.IncludeBreadcrumb)
                    ViewBag.Breadcrumb = Tools.SetBreadcrumb(page, ViewBag.Menu);

                if (page.IsMainpage)
                    return await Home(page);
                else
                {
                    if (page.Template == PageTemplate.Static)
                        return await StaticPage(page);
                    else
                        return View(page);
                }
            }
            else
            {
                var products = ViewBag.Products as List<Product>;
                var productPage = products.FirstOrDefault(p => p.Url == Url);
                if (productPage != null)
                {
                    ViewBag.IncludeBreadcrumb = true;
                    var menu = (ViewBag.Menu as List<Menu>).FirstOrDefault(p => p.IsHaveProducts);
                    ViewBag.Breadcrumb = Tools.SetProductBreadcrumb(productPage, menu);
                    return Product(productPage);
                }
                else
                {
                    Response.StatusCode = 404;
                    return View(Paths.Views.NotFound);
                }
            }
        }

        public async Task<List<SearchResult>> SearchResults()
        {
            List<SearchResult> results = new List<SearchResult>();
            CultureInfo culture = new CultureInfo("tr-TR");
            string query = Request.QueryString["q"].ToLower(culture);
            if (!String.IsNullOrEmpty(query))
            {
                //search in pages
                var pages = await ContentfulAPI.Delivery.GetAllPages();
                var filteredItems = pages.Where(p => p.Content != null && p.Content.ToLower(culture).Contains(query)).Select(x => new SearchResult
                {
                    Title = !String.IsNullOrEmpty(x.MetaTitle) ? x.MetaTitle : x.Title,
                    Description = x.MetaDescription,
                    Link = string.Format("{0}://{1}/{2}", Request.Url.Scheme, Request.Url.Authority, x.Url.TrimStart('/'))
                }).ToList();

                //search in products
                var products = ViewBag.Products as List<Product>;
                filteredItems.AddRange(products.Where(p => p.Name.ToLower(culture).Contains(query) || p.Summary.ToLower(culture).Contains(query) || p.Description.ToLower(culture).Contains(query) || p.Features.ToString(culture).Contains(query) || p.TabContents.ToString(culture).Contains(query)).Select(x => new SearchResult
                {
                    Title = !String.IsNullOrEmpty(x.MetaTitle) ? x.MetaTitle : x.Name,
                    Description = x.MetaDescription,
                    Link = string.Format("{0}://{1}/{2}", Request.Url.Scheme, Request.Url.Authority, x.Url.TrimStart('/'))
                }).ToList());

                //search in faq
                var FAQs = await ContentfulAPI.Delivery.GetFAQs();
                filteredItems.AddRange(FAQs.Where(p => p.Question.ToString(culture).Contains(query) || p.Answer.ToString(culture).Contains(query)).Select(x => new SearchResult
                {
                    Title = "Sıkça Sorulan Sorular",
                    Description = x.Question.ToString(culture).Contains(query) ? x.Question : x.Answer,
                }).ToList());

                //search in campaigns
                var campaigns = await ContentfulAPI.Delivery.GetCampaigns();
                filteredItems.AddRange(campaigns.Where(p => p.Name.ToString(culture).Contains(query) || p.Content.ToString(culture).Contains(query)).Select(x => new SearchResult
                {
                    Title = x.Name,
                    Description = x.Content
                }).ToList());

                results.AddRange(filteredItems);
            }

            return results;
        }
    }
}