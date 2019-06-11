using IRunesWebApp.Data;
using SIS.MvcFramework;
using SIS.WebServer.Routing;

namespace IRunes.App
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new IRunesContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices()
        {
        }
    }
}
