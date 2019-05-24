namespace IRunesWebApp
{
    using IRunesWebApp.Controllers;
    using SIS.HTTP.Enums;
    using SIS.MvcFramework;
    using SIS.WebServer;
    using SIS.WebServer.Api;
    using SIS.WebServer.Results;
    using SIS.WebServer.Routing;
    using System.Reflection;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            var handler = new HttpHandler(serverRoutingTable);
            MvcContext.Get.AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            ConfigureRouting(serverRoutingTable);
           

            Server server = new Server(80, handler);
            server.Run();

        }
        private static void ConfigureRouting(ServerRoutingTable serverRoutingTable)
        { 
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/home/index"] = request => new RedirectResult("/");
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/login"] = request => new UsersController().Login(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/register"] = request => new UsersController().Register(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/login"] = request => new UsersController().LoginPost(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/register"] = request => new UsersController().RegisterPost(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/all"] = request => new AlbumsController().All(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/create"] = request => new AlbumsController().CreateGet(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/albums/create"] = request => new AlbumsController().CreatePost(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/logout"] = request => new UsersController().Logout(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/details"] = request => new AlbumsController().Details(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/tracks/create"] = request => new TracksController().CreateGet(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/tracks/create"] = request => new TracksController().CreatePost(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/tracks/details"] = request => new TracksController().Details(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/forgottenPassword"] = request => new UsersController().SetNewPasswordGet(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/forgottenPassword"] = request => new UsersController().SetNewPasswordPost(request);
        }
    }
}
