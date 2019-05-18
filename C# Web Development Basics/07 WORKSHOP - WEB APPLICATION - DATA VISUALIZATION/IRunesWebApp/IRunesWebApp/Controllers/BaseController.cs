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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public abstract class BaseController
    {
        private const string RoothDirectoryBackPath = "../../../";
        private const string ViewsFolderName = "Views";
        private const string DirectorySeperator = "/";
        private const string LayoutFFileName = "_Layout";
        private const string HtmlFileExtension = ".html";
        private const string RenderBodyConstant = "@RenderBody()";

        public BaseController()
        {
            this.DbContext = new IRunesContext();
            this.userCookieService = new UserCookieService();
            this.ViewBag = new Dictionary<string, string>();
        }

        protected IRunesContext DbContext { get; set; }
        protected IUserCookieService userCookieService;
        protected IDictionary<string, string> ViewBag { get; set; }

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            //var filePath = "Views/" + viewName + ".html";
            var layoutView = RoothDirectoryBackPath +
                ViewsFolderName +
                DirectorySeperator +
                LayoutFFileName +
                HtmlFileExtension;

            var filePath = RoothDirectoryBackPath +
                ViewsFolderName +
                DirectorySeperator +
                this.GetCurrentControllerName() +
                DirectorySeperator +
                viewName +
                HtmlFileExtension;

            if (!File.Exists(filePath))
            {
                return this.NotFoundError("View not found!");
            }

            var viewContent = BuildViewContent(filePath);
            var viewLayout = File.ReadAllText(layoutView);

            if (viewName == "Index" || viewName == "Login" || viewName == "Register")
            {
                return new HtmlResult(viewContent, HttpResponseStatusCode.Ok);
            }
            else
            {
                var view = viewLayout.Replace(RenderBodyConstant, viewContent);
                return new HtmlResult(view, HttpResponseStatusCode.Ok);
            }
        }

        private string BuildViewContent(string filePath)
        {
            var viewContent = File.ReadAllText(filePath);

            foreach (var key in ViewBag.Keys)
            {
                if (viewContent.Contains($"{{{{{key}}}}}"))
                {
                    viewContent = viewContent.Replace($"{{{{{key}}}}}", this.ViewBag[key]);
                }
            }
            return viewContent;
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

        private string GetCurrentControllerName() => this.GetType().Name.Split("Controller").FirstOrDefault();
    }
}
