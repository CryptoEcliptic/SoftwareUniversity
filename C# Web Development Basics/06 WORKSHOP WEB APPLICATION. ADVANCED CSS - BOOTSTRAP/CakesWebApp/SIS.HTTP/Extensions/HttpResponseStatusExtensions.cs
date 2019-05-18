namespace SIS.HTTP.Extensions
{
    using SIS.HTTP.Enums;
    using System.Net;

    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode statusCode)
        {
            return $"{(int)statusCode} {statusCode}";
        }
    }
}
