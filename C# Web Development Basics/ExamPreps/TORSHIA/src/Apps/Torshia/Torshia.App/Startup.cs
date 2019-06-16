using SIS.MvcFramework;
using SIS.MvcFramework.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using Torshia.Data;
using Torshia.Services;

namespace Torshia.App
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            // Once on start
            using (var db = new TorshiaDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(SIS.MvcFramework.DependencyContainer.IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUsersService, UsersService>();
            serviceProvider.Add<ITasksService, TasksService>();
            //serviceProvider.Add<IOrdersService, OrdersService>();
        }
    }
}
