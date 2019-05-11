namespace SIS.Demoo
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>Hello Worldddd!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}
