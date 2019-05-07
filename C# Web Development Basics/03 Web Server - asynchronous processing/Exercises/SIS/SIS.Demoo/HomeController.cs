namespace SIS.Demoo
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>I need a real beer!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}
