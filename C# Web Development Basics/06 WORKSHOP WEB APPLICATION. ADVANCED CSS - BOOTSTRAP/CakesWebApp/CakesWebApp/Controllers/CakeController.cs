namespace CakesWebApp.Controllers
{
    using CakesWebApp.Data;
    using CakesWebApp.Extensions;
    using CakesWebApp.Models;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CakeController : BaseController
    {
        private CakeContext dbContext;

        public CakeController()
        {
            this.dbContext = new CakeContext();
        }

        public IHttpResponse AddCakeGet(IHttpRequest request)
        { 
            return this.View("Cakes/AddCake");
        }

        public IHttpResponse AddCakePost(IHttpRequest request)
        {
            var name = request.FormData["name"].ToString().Trim().UrlDecode();
            var price = decimal.Parse(request.FormData["price"].ToString().UrlDecode(), CultureInfo.InvariantCulture);
            var url = request.FormData["url"].ToString().Trim().UrlDecode();

            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 36)
            {
                return this.Error("Cake name should be between 3 and 36 characters!");
            }

            if (price < 1 || price > 100)
            {
                return this.Error("Cake price should be between 1 and 100 USD!");
            }

            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrEmpty(url))
            {
                return this.Error("Please provide a valid Url!");
            }

            var cake = new Product
            {
                Name = name,
                Price = price,
                ImageUrl = url
            };

            try
            {
                this.dbContext.Products.Add(cake);
                this.dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            return new RedirectResult("/cakes/all");
        }

        public IHttpResponse AllCakes(IHttpRequest request)
        {
            var cakes = this.dbContext.Products.ToList();
            var result = new StringBuilder();

            if (cakes.Count == 0)
            {
                result.AppendLine("<p>No available cakes in stock!</p>");
            }

            else
            {
                foreach (var cake in cakes)
                {
                    result.AppendLine($"<a href=\"/cakes/details?cakeId={cake.Id}\">{cake.Name} ${cake.Price}</a> " +
                        $"<img src=\"{cake.ImageUrl}\" class=\"imx-auto d-block\" width=\"304\" height=\"236\"><hr/>");
                }
            }

            var viewBag = new Dictionary<string, string>();
            viewBag["AllCakes"] = result.ToString();

            return this.View("Cakes/All", viewBag);
        }

        public IHttpResponse GetDetails(IHttpRequest request)
        {
            var cakeId = int.Parse(request.QueryData["cakeId"].ToString());
            var cake = this.dbContext.Products.FirstOrDefault(x => x.Id == cakeId);

            var viewBag = new Dictionary<string, string>();
            viewBag["Name"] = cake.Name;
            viewBag["Price"] = cake.Price.ToString("F2");
            viewBag["Link"] = cake.ImageUrl;

            return this.View("Cakes/Details", viewBag);
        }

    }
}
