namespace CakesWebApp
{
    using CakesWebApp.Controllers;
    using SIS.HTTP.Enums;
    using SIS.WebServer;
    using SIS.WebServer.Routing;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/register"] = request => new AccountController().Register(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/login"] = request => new AccountController().Login(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/register"] = request => new AccountController().DoRegister(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/login"] = request => new AccountController().DoLogin(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/home"] = request => new HomeController().HomeUser(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/logout"] = request => new AccountController().Logout(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/profile"] = request => new AccountController().GetUserData(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/cakes/add"] = request => new CakeController().AddCakeGet(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/cakes/add"] = request => new CakeController().AddCakePost(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/cakes/all"] = request => new CakeController().AllCakes(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/cakes/details"] = request => new CakeController().GetDetails(request);

            Server server = new Server(80, serverRoutingTable);
            server.Run();
        }
    }
}
