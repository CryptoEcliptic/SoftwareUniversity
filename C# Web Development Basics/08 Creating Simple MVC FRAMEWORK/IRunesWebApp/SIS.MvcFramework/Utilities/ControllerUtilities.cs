﻿namespace SIS.MvcFramework.Utilities
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

        public static string GetViewFullQualifiedName(string controller, string action)
        {
            return string.Format("{0}\\{1}\\{2}", MvcContext.Get.ViewsFolder, controller, action);
        }
    }
}
