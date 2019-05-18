namespace CakesWebApp.Extensions
{
    using System.Net;

    public static class StringExtension
    {
        public static string UrlDecode(this string url)
        {
            return WebUtility.UrlDecode(url);
        }
    }
}
