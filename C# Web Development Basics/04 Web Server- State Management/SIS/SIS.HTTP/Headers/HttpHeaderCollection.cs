namespace SIS.HTTP.Headers
{
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Headers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (string.IsNullOrEmpty(header.Key) || string.IsNullOrEmpty(header.Value))
            {
                throw new BadRequestException();
            }
            this.headers[header.Key] = header;
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new BadRequestException();
            }

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"{nameof(key)} cannot be null.");
            }

            return headers[key];
        }

        public override string ToString()
        {
            var headersToReturn = new StringBuilder();
            foreach (var header in headers)
            {
                headersToReturn.AppendLine(header.Value.ToString());
            }

            return headersToReturn.ToString().TrimEnd();
        }
    }
}
