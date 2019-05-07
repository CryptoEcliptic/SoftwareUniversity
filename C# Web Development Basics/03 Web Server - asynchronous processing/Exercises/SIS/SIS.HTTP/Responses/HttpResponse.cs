namespace SIS.HTTP.Responses
{
    using SIS.HTTP.Common;
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

        public HttpResponse(){ }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Content = new byte[0];
            this.Headers = new HttpHeaderCollection();
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public byte[] Content { get; set ; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            byte[] result = Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();

            return result;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output
                .AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {HttpResponseStatusExtensions.GetResponseLine(this.StatusCode)}")
                .AppendLine($"{this.Headers}")
                .Append(Environment.NewLine);

            return output.ToString();
        }
    }
}
