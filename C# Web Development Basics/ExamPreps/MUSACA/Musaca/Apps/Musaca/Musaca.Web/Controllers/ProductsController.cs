using Musaca.Services;
using Musaca.Web.VewModels.Products;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musaca.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateProductVewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Products/Create");
            }

           this.productsService.CreateProduct(model.Name, model.Price);

            return this.Redirect("/Products/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var products = this.productsService.GetAllProducts()
               .Select(x => new PrezentProductViewModel
               {
                   Name = x.Name,
                   Price = x.Price
               }).ToList();

            return this.View(products);
        }
    }
}
