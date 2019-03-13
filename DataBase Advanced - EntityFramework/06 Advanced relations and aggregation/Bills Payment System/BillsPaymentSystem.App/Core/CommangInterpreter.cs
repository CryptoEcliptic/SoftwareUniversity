namespace BillsPaymentSystem.App.Core
{
    using BillsPaymentSystem.App.Core.Commands.Contracts;
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using System;
    using System.Linq;
    using System.Reflection;

    class CommangInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";

        public string Read(string[] args, BillsPaymentSystemContext context)
        {
            string command = args[0];
            string[] commandArgs = args.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == command + Suffix);

            if (type == null)
            {
                throw new ArgumentNullException(null, "Command not found!");
            }

            var instance = Activator.CreateInstance(type, context);

            var result = ((ICommandInterface)instance).Execute(commandArgs);

            return result;
        }
    }
}
