namespace IRunesWebApp.Controllers
{
    using IRunesWebApp.Models;
    using IRunesWebApp.Services;
    using IRunesWebApp.Services.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Linq;

    public class UsersController : BaseController
    {
        private IPasswordHasher passwordHasher;
   
        public UsersController()
        {
            this.passwordHasher = new PasswordHasher(); 
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View("Login");
        }

        public IHttpResponse LoginPost(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();

            var hashedPassword = this.passwordHasher.HashPassword(password);
            var user = this.DbContext.Users.FirstOrDefault(x => x.Username == username && x.Password == hashedPassword);

            if (user == null)
            {
                return this.BadRequestError("Incorrect username or password!");
            }
            var response = new RedirectResult("/");
            this.SignInUser(username, request, response);
           
            return response;
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View("Register");
        }

        public IHttpResponse RegisterPost(IHttpRequest request)
        {
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();
            var email = HtmlDecoder.Decode(request.FormData["email"].ToString());

            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 3)
            {
                return this.BadRequestError("Username should be more than 2 characters");
            }

            if (this.DbContext.Users.Any(x => x.Username == userName))
            {
                return this.BadRequestError("This username already exists in the database!");
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return this.BadRequestError("The password should be at least 6 characters!");
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError("Password and Confirm password fields do not match!");
            }

            //Hashing password
            string hashedPassword = this.passwordHasher.HashPassword(password);

            var user = new User
            {
                Username = userName,
                Password = hashedPassword,
                Email = email
            };

            //Save data in the DB
            try
            {
                this.DbContext.Users.Add(user);
                this.DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            //Redirect to home page
            return new RedirectResult("/");
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-IRunes"))
            {
                return new RedirectResult("/");
            }

            var cookie = request.Cookies.GetCookie(".auth-IRunes");
            cookie.Delete();
            request.Session.ClearParameters();

            var response = new RedirectResult("/");
            response.Cookies.Add(cookie);

            return response;
        }

        public IHttpResponse SetNewPasswordGet(IHttpRequest request)
        {
            return this.View("ForgotPassword");
        }

        public IHttpResponse SetNewPasswordPost(IHttpRequest request)
        {
            var email = HtmlDecoder.Decode(request.FormData["email"].ToString());

            if (!this.DbContext.Users.Any(x => x.Email == email))
            {
                return this.View("InvalidEmail");
            }

            return new RedirectResult("/");
            //TODO rendom password generator for generating temp password
            //TODO find a way to sent the temp password to the user email
        }
    }
}
