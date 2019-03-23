using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Contracts;
using MyApp.DbInitializer.Contracts;
using System;
using System.Linq;

namespace MyApp.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            IDatabaseService databaseService = this.serviceProvider.GetService<IDatabaseService>();
            databaseService.InitializeDatabase();

            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();

                try
                {
                    string result = commandInterpreter.Read(inputArgs);

                    Console.WriteLine(result);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            
           

            //TODO Catch necessary exceptions
        }
    }
}
