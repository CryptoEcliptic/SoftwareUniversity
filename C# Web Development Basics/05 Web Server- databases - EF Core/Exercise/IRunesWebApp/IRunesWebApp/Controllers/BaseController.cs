namespace IRunesWebApp.Controllers
{
    using IRunesWebApp.Data;
    using IRunesWebApp.Services;
    using IRunesWebApp.Services.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System.Collections.Generic;
    using System.IO;

    public abstract class BaseController
    {
        private const string RoothDirectoryBackPath = "../../../";
        private const string ViewsFolderName = "Views";
        private const string HtmlFileExtension = ".html";
        

        public BaseController()
        {
            this.DbContext = new IRunesContext();
            this.userCookieService = new UserCookieService();
            this.ViewBag = new Dictionary<string, string>();
        }

        protected IRunesContext DbContext { get; set; }
        protected IUserCookieService userCookieService;
        protected IDictionary<string, string> ViewBag { get; set; }

        protected IHttpResponse View(string viewName)
        {
            var filePath = "Views/" + viewName + ".html";
            var response = File.ReadAllText(filePath);

            foreach (var key in ViewBag.Keys)
            {
                if (response.Contains($"{{{{{key}}}}}"))
                {
                    response = response.Replace($"{{{{{key}}}}}", this.ViewBag[key]);
                }
            }

            return new HtmlResult(response, HttpResponseStatusCode.Ok);   
        }
  
        protected IHttpResponse BadRequestError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpResponseStatusCode.BadRequest);
        }

        protected IHttpResponse NotFoundError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpResponseStatusCode.NotFound);
        }

        protected IHttpResponse ServerError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpResponseStatusCode.InternalServerError);
        }

        protected void SignInUser(string userName, IHttpRequest request, IHttpResponse response)
        {
            request.Session.AddParameter("username", userName);
            var userCookieValue = this.userCookieService.GetUserCookie(userName);

            response.Cookies.Add(new HttpCookie(".auth-IRunes", userCookieValue, 9));
        }

        public bool IsAuthenticated(IHttpRequest request)
        {
            return request.Session.ContainsParameter("username");
        }

        protected IHttpResponse RedirectToAction(string route) => new RedirectResult(route);
    }
}
