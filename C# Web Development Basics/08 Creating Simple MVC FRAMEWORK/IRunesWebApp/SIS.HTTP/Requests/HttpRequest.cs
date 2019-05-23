﻿namespace SIS.HTTP.Requests
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Sessions;
    using SIS.HTTP.Sessions.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpCookieCollection Cookies { get; private set; }

        public IHttpSession Session { get; set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(Environment.NewLine);

            string[] requestLine = splitRequestContent[0]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            string[] headers = splitRequestContent.Skip(1).ToArray();
            this.ParseHeaders(headers);
            this.ParseCookies();

    
            string requestParameters = splitRequestContent[splitRequestContent.Length - 1];
            bool requestHasBody = splitRequestContent.Length > 1;
            this.ParseRequestParameters(requestParameters, requestHasBody);
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(GlobalConstants.CookieRequestHeaderName))
            {
                return;
            }

            string cookieRow = this.Headers.GetHeader(GlobalConstants.CookieRequestHeaderName).Value;
            string[] cookiesArray = cookieRow.Split("; ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var cookie in cookiesArray)
            {
                var currentCookie = cookie.Split(GlobalConstants.KeyValuePairDelimiter, 2);

                var key = currentCookie[0];
                var value = currentCookie[1];

                this.Cookies.Add(new HttpCookie(key, value));
            }
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            if (requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }

            return false;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            string method = requestLine[0];

            HttpRequestMethod requestMethod;
            bool isParsed = Enum.TryParse(method, true, out requestMethod);

            if (!isParsed)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = requestMethod;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }
           
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            string path = this.Url.Split("?").FirstOrDefault();

            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseHeaders(string[] headers)
        {
            bool containsHostHeader = false;

            if (!headers.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in headers)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    return;
                }

                var splitRequestHeader = requestHeader.Split(GlobalConstants.SplitHeader, StringSplitOptions.RemoveEmptyEntries);
                var key = splitRequestHeader[0];
                var value = splitRequestHeader[1];

                var currentHeader = new HttpHeader(key, value);
                this.Headers.Add(currentHeader);

                if (key == "Host")
                {
                    containsHostHeader = true;
                }
            }

            if (!containsHostHeader)
            {
                throw new BadRequestException();
            }
        }

        private void ParseRequestParameters(string bodyParameters, bool requestHasBody)
        {
            if (this.Url.Contains("?"))
            {
                this.ParseQueryParameters();
            }

            if (requestHasBody)
            {
                this.ParseFormDataParameters(bodyParameters);
            }
        }

        private void ParseQueryParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            var queryString = this.Url.Split(new char[] { '?', '#' })[1];

            if (string.IsNullOrEmpty(queryString))
            {
                return;
            }

            string[] queryKvp = queryString.Split('&');

            ExtractRequestedParameters(queryKvp, this.QueryData);
           
        }

        private void ParseFormDataParameters(string bodyParameters)
        {
            string[] queryKvp = bodyParameters
                .Split("&", StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestedParameters(queryKvp, this.FormData);
        }

        private void ExtractRequestedParameters(string[] queryKvp, Dictionary<string, object> parametersCollection)
        {
            foreach (var line in queryKvp)
            {
                var kvp = line.Split("=", StringSplitOptions.RemoveEmptyEntries);

                if (kvp.Length != 2)
                {
                    throw new BadRequestException();
                }
                var key = kvp[0];
                var value = kvp[1];

                parametersCollection[key] = value;
            }
        }

        //private void ProcessParameters(string[] queryParameters, Dictionary<string, object> data)
        //{
        //    foreach (var query in queryParameters)
        //    {
        //        var currentQuery = query.Split(GlobalConstants.KeyValuePairDelimiter, StringSplitOptions.RemoveEmptyEntries);

        //        if (currentQuery.Length != 2)
        //        {
        //            throw new BadRequestException();
        //        }

        //        var key = currentQuery[0];
        //        var value = currentQuery[1];

        //        data[key] = value;
        //    }
        //}

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return !string.IsNullOrEmpty(queryString) && queryParameters.Length > 0;

        }
    }
}
