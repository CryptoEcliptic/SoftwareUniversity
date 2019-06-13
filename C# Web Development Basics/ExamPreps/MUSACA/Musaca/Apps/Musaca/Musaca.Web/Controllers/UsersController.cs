using Musaca.Data.Models;
using Musaca.Services;
using Musaca.Web.VewModels.Orders;
using Musaca.Web.VewModels.Users;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Linq;

namespace Musaca.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IOrdersService ordersService;

        public UsersController(IUsersService usersService, IOrdersService ordersService)
        {
            this.usersService = usersService;
            this.ordersService = ordersService;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            var user = this.usersService.CreateUser(model.Username, model.Email, model.Password);

            this.SignIn(user.Id, user.Username, user.Email);
            this.ordersService.CreateOrder(user.Id);

            return this.Redirect("/");
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            User userFromDb = this.usersService.GetUserByUsernameAndPassword(model.Username, model.Password);

            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);
  
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var usersOrders = this.usersService.ShowAllUsersOrders(this.User.Id)
                .Select(x => new UserOrdersView
                {
                    Id = x.Id,
                    Cashier = x.Cashier.Username,
                    IssuedOn = x.IssuedOn.ToString("dd/MM/yyyy"),
                    Total = x.Products.Sum(p => p.Price),
                })
                .ToList();

            return this.View(new AllUsersOrdersList { Orders = usersOrders });
        }

        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
