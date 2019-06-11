using Panda.Data.Models;
using Panda.Services;
using Panda.Web.ViewModels.Users;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService userService;

        public UsersController(IUsersService userService)
        {
            this.userService = userService;
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

            var user = this.userService.CreateUser(model.Username, model.Email, model.Password);

            this.SignIn(user.Id, user.Username, user.Email);

            return this.Redirect("/");     
        }


        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            User userFromDb = this.userService.GetUserByUsernameAndPassword(model.Username, model.Password);

            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect("/");
        }

        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
