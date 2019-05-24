namespace SIS.MvcFramework.Routers
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Responses.Contracts;
    using SIS.MvcFramework.ActionResults.Contracts;
    using SIS.MvcFramework.Attributes.Methods;
    using SIS.MvcFramework.Controllers;
    using SIS.WebServer.Api;
    using SIS.WebServer.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ControllerRouter : IHttpHandler
    {
        private const string DefaultControllerName = "Home";
        private const string DefaultActionName = "Index";
        
        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestmethod = request.RequestMethod.ToString();

            if (request.Url == "/")
            {
                controllerName = DefaultControllerName;
                actionName = DefaultActionName;
            }

            else
            {
                var requestUrlSplit = request.Url.Split('/', StringSplitOptions.RemoveEmptyEntries);
                controllerName = requestUrlSplit[0];
                actionName = requestUrlSplit[1];
            }

            var controller = this.GetController(controllerName, request);
            MethodInfo action = this.GetMethod(requestmethod, controller, actionName);

            if (action == null || controller == null)
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.PrepareResponse(controller, action);
        }

        private Controller GetController(string controllerName, IHttpRequest request)

        {
            if (string.IsNullOrEmpty(controllerName))
            {
                return null;
            }

            string controllerTypeName = $"{MvcContext.Get.AssemblyName}.{MvcContext.Get.ControllersFolder}.{controllerName}{MvcContext.Get.ControllersSufix}, {MvcContext.Get.AssemblyName}";

            var controllerType = Type.GetType(controllerTypeName);
            var controller = (Controller)Activator.CreateInstance(controllerType);

            if (controller != null)
            {
                controller.Request = request;
            }

            return controller;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            foreach (var methodIfo in GetSuitableMethods(controller, actionName))
            {
                var attributes = methodIfo
                    .GetCustomAttributes()
                    .Where(x => x is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>()
                    .ToList();

                if (!attributes.Any() && requestMethod.ToUpper() == "GET")
                {
                    return methodIfo;
                }

                foreach (var attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodIfo;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(x => x.Name.ToLower() == actionName.ToLower());

        }

        private IHttpResponse PrepareResponse(Controller controller, MethodInfo action)
        {
            IActionResult actionResult = (IActionResult)action.Invoke(controller, null);
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.Ok);
            }

            else if (actionResult is IRedirectable)
            {
                return new RedirectResult(invocationResult);
            }

            else
            {
                throw new InvalidOperationException("The view result is not supported!");
            }
        }
    }
}
