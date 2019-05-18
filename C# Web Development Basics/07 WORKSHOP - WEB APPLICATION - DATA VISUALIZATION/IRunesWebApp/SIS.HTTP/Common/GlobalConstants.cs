namespace SIS.HTTP.Common
{
    public abstract class GlobalConstants
    {
        public const string HttpOneProtocolFragment = "HTTP/1.1";
        public const string HostHeaderKey = "Host";
        public const string SplitHeader = ": ";
        public const string KeyValuePairDelimiter = "=";
        public const string CookieRequestHeaderName = "Cookie";
        public static string[] ResourceExtensions = new string[] { ".js", ".css" };
    }
}
