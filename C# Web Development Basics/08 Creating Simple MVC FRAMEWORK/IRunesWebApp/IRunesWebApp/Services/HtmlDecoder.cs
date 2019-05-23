namespace IRunesWebApp.Services.Contracts
{
    using System.Web;

    public static class HtmlDecoder
    {
        public static string Decode(string textToDecode)
        {
            return HttpUtility.UrlDecode(textToDecode);
        }
    }
}
