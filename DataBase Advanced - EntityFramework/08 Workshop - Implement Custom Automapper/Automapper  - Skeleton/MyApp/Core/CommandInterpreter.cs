using MyApp.Core.Commands.Contracts;
using MyApp.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace MyApp.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] args)
        {
            string command = args[0];
            string[] arguments = args.Skip(1).ToArray();

            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == command + Suffix);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid command, men!");
            }

            var constructor = type
                .GetConstructors()
                .FirstOrDefault();

            var ctorParameters = constructor.GetParameters()
                .Select(x => x.ParameterType)
                .ToArray(); 

            var services = ctorParameters
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var instance = (ICommand)Activator.CreateInstance(type, services);

            string result = instance.Execute(arguments);

            return result;
        }
    }
}
