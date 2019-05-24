namespace SIS.Demo
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Routers;
    using SIS.WebServer;

    class Launcher
    {
        static void Main(string[] args)
        {
            var server = new Server(80, new ControllerRouter());
            MvcEngine.Run(server);
        }
    }
}
