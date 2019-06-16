using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using Torshia.App.VewModels.Users;
using Torshia.Data.Models;
using Torshia.Services;

namespace Torshia.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
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

            //Create user service method
            this.usersService.CreateUser(model.Username, model.Email, model.Password);

            return this.Redirect("/Users/Login");
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
           
            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email); //Initializing the Principal
            this.User.Roles.Add(userFromDb.Role.ToString()); //Adding Role to the Proncipal

            return this.Redirect("/");
        }

        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
