namespace CakesWebApp.Controllers
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using System.Collections.Generic;

    public class CakeController : BaseController
    {
        public IHttpResponse AddCake(IHttpRequest request)
        {
            var viewBag = new Dictionary<string, string>();
            return this.View("AddCake", viewBag);
        }
        //TODO Add DoAddCake method
    }
}
