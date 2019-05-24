namespace SIS.MvcFramework.Utilities
{
    public static class ControllerUtilities
    {
        public static string GetControllerName(object controller)
        {
            return controller
                .GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSufix, string.Empty);
        }

        public static string GetViewFullQualifiedName(string controllerName, string action)
        {
            return string.Format("{0}/{1}/{2}.html", MvcContext.Get.ViewsFolder, controllerName, action);
        }
    }
}
