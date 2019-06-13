using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musaca.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddProduct(string product)
        {
            var userId = this.User.Id;

            this.ordersService.AddProductToOrder(product, userId);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Cashout()
        {
            var userId = this.User.Id;

            this.ordersService.CahsoutCurrentOrder(userId);

            return this.Redirect("/");
        }

    }
}
