namespace SIS.MvcFramework.Controllers
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.MvcFramework.ActionResults;
    using SIS.MvcFramework.ActionResults.Contracts;
    using SIS.MvcFramework.Utilities;
    using SIS.MvcFramework.Views;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Controller() { }

        public IHttpRequest Request { get; set; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            var fullyQualifiedName = ControllerUtilities.GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }
    }
}
