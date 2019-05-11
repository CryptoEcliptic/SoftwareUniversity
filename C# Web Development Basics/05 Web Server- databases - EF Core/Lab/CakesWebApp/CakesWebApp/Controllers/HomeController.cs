namespace CakesWebApp.Controllers
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System.Collections.Generic;

    internal class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            return this.View("Index");
        }

        public IHttpResponse HomeUser(IHttpRequest request)
        {
            var viewBag = new Dictionary<string, string>();
            return this.View("Home", viewBag);
        }
    }
}