using Musaca.Services;
using Musaca.Web.VewModels.Home;
using Musaca.Web.VewModels.Products;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using System.Linq;

namespace Musaca.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var products = this.productsService.GetAllProductsFromCurrentOrder(this.User.Id)
                    .Select(x => new OrderedProductsViewModel
                    {
                        Name = x.Name,
                        Price = x.Price,
                    })
                    .ToList();
                var sum = products.Sum(x => x.Price);
                

                return this.View(new CurrentActiveOrderViewModel { Products = products, Sum = sum }, "IndexLoggedIn");
            }
            return this.View();
        }
    }
}
