namespace CakesWebApp.Controllers
{
    using CakesWebApp.Data;
    using CakesWebApp.Models;
    using CakesWebApp.Services;
    using CakesWebApp.Services.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class AccountController : BaseController
    {
        private const string UnsuccessfullLoginMessage = "Incorrect username or password!";
        private CakeContext dbContext;
        private IPasswordHasher passwordHasher;


        public AccountController()
        {
            this.dbContext = new CakeContext();
            this.passwordHasher = new PasswordHasher();

        }

        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View("Register");
        }

        public IHttpResponse DoRegister(IHttpRequest request)
        {
            //1. Validate,
            //2. Generate password hash
            //3. Create User
            //4 Save user to db
            //Redirect to home page
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();
            //Validation
            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 3)
            {
                return this.Error("Username should be more than 2 characters");
            }

            if (this.dbContext.Users.Any(x => x.Username == userName))
            {
                return this.Error("This username already exists in the database!");
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return this.Error("The password should be at least 6 characters!");
            }

            if (password != confirmPassword)
            {
                return this.Error("Password and Confirm password fields do not match!");
            }
            //Hashing password
            string hashedPassword = this.passwordHasher.HashPassword(password);

            var user = new User
            {
                Name = userName,
                Username = userName,
                Password = hashedPassword
            };

            //Save data in the DB
            try
            {
                this.dbContext.Users.Add(user);
                this.dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            //Redirect to home page
            return new RedirectResult("/");
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View("Login");
        }

        public IHttpResponse DoLogin(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Error(UnsuccessfullLoginMessage);
            }

            var passwordHash = this.passwordHasher.HashPassword(password);

            var user = this.dbContext.Users
                .FirstOrDefault(x => x.Username == username
                && x.Password == passwordHash);

            if (user == null)
            {
                return Error(UnsuccessfullLoginMessage);
            }
            var cookieContent = this.cookieService.GetUserCookie(user.Username);

            var response = this.View("Home");
            response.Cookies.Add(new HttpCookie(".auth-cakes", cookieContent, 1));
            return response;
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return new RedirectResult("/");
            }

            var cookie = request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();

            var response = new RedirectResult("/");
            response.Cookies.Add(cookie);

            return response;
        }

        public IHttpResponse GetUserData(IHttpRequest request)
        {
            var userName = this.GetUser(request);
            var user = this.dbContext.Users.FirstOrDefault(x => x.Username == userName);

            var viewBag = new Dictionary<string, string>
            {
                {"Name", user.Name},
                {"Username", user.Username},
                {"RegistrationDate", user.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)},
                {"OrdersCount", user.Orders.Count().ToString()},

            };
            return this.View("Profile", viewBag);
        }
    }
}
