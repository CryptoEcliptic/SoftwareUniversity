namespace SIS.WebServer.Api
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using SIS.WebServer.Routing;
    using System;
    using System.IO;
    using System.Linq;

    public class HttpHandler : IHttpHandler
    {
        private const string RootDirectoryRelativePath = "../../..";
        private ServerRoutingTable serverRoutingTable;

        public HttpHandler(ServerRoutingTable routingTable)
        {
            this.serverRoutingTable = routingTable;
        }

        public IHttpResponse Handle(IHttpRequest httpRequest)
        {
            var isResourceRequest = this.IsResourceRequest(httpRequest);

            if (isResourceRequest)
            {
                return this.HandleRequestResponse(httpRequest.Path);
            }

            if (!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod)
           || !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
        }

        private bool IsResourceRequest(IHttpRequest httpRequest)
        {
            var requestPath = httpRequest.Path;
            if (requestPath.Contains('.'))
            {
                var requestPathExtension = requestPath.Substring(requestPath.LastIndexOf('.'));
                return GlobalConstants.ResourceExtensions.Contains(requestPathExtension);
            }
            return false;
        }

        private IHttpResponse HandleRequestResponse(string httpRequestPath)
        {
            var startIndexOfExtension = httpRequestPath.LastIndexOf('.');
            var resourceNameStartIndex = httpRequestPath.LastIndexOf('/');

            var requestPathExtension = httpRequestPath.Substring(startIndexOfExtension);
            var resourceName = httpRequestPath.Substring(resourceNameStartIndex);

            var resourcePath = RootDirectoryRelativePath
                + "/Resources"
                + $"/{requestPathExtension.Substring(1)}"
                + resourceName
                ;

            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);
            return new InlineResourceResult(fileContent, HttpResponseStatusCode.Ok);
        }
    }
}
