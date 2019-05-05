namespace HttpProtocolExercise
{
    using System;
    using System.Net;
    using System.Text;

    public class UrlValidator
    {
        public string ValidateUrl(string input)
        {
            var decodedUrl = WebUtility.UrlDecode(input);
            StringBuilder result = new StringBuilder();
            try
            {
                var url = new Uri(decodedUrl);

                if (string.IsNullOrEmpty(url.Scheme)
                    || string.IsNullOrEmpty(url.Host)
                    || string.IsNullOrEmpty(url.Port.ToString())
                    || string.IsNullOrEmpty(url.LocalPath) || !url.Host.Contains("."))
                {
                    throw new ArgumentException("Invalid Url!");
                }

                result.AppendLine($"Protocol: {url.Scheme}");
                result.AppendLine($"Host: {url.Host}");
                result.AppendLine($"Port: {url.Port}");
                result.AppendLine($"Path: {url.LocalPath}");

                if (!string.IsNullOrEmpty(url.Query))
                {
                    result.AppendLine($"Query: {url.Query}");
                    result.AppendLine($"Fragment: {url.Fragment.TrimStart('#')}");
                }
     
                return result.ToString().TrimEnd();
            }
            catch (Exception)
            {
                return "Invalid Url";
            }
        }
    }
}
