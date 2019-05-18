namespace SIS.HTTP.Responses
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Extensions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {

        public HttpResponse() { }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Content = new byte[0];
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public IHttpCookieCollection Cookies { get; private set; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            byte[] result = Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();

            return result;
        }

        public void AddCookie(HttpCookie cookie)
        {
            if (string.IsNullOrEmpty(cookie.Key) || string.IsNullOrEmpty(cookie.Value))
            {
                throw new BadRequestException();
            }

            this.Cookies.Add(cookie);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output
                .AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {HttpResponseStatusExtensions.GetResponseLine(this.StatusCode)}")
                .AppendLine($"{this.Headers}");

            if (this.Cookies.HasCookies())
            {
                foreach (var httpCookie in this.Cookies)
                {
                    output.AppendLine($"Set-Cookie: {httpCookie.ToString()}");
                }
            }

            output.Append(Environment.NewLine);

            return output.ToString();
        }
    }
}
