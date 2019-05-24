namespace SIS.MvcFramework
{
    using SIS.WebServer;
    using System;
    using System.Reflection;

    public static class MvcEngine
    {
        public static void Run(Server server)
        {
            RegisterAssemblyName();
            RegisterControllersData();
            RegisterViewsData();
            RegisterModelsData();

            try
            {
                server.Run();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }

        private static void RegisterModelsData()
        {
            MvcContext.Get.ModelsFolder = "Models";
        }

        private static void RegisterViewsData()
        {
            MvcContext.Get.ModelsFolder = "Views";
        }

        private static void RegisterControllersData()
        {
            MvcContext.Get.ControllersFolder = "Controllers";
            MvcContext.Get.ControllersSufix = "Controller";
        }
    }
}
