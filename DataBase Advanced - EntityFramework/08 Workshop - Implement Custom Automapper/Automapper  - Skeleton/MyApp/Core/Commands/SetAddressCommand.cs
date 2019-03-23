using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System;
using System.Linq;

namespace MyApp.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private readonly MyCompanyContext context;

        public SetAddressCommand(MyCompanyContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            string address = string.Join(" ", args.Skip(1).ToArray());

            var employee = this.context.Employees.Find(id);

            if (employee == null)
            {
                throw new ArgumentNullException(null, $"No employee with id {id}!");
            }

            employee.Address = address;
            context.SaveChanges();

            return $"Successfully updated birthday of {employee.FirstName} {employee.LastName}";
        }
    }
}
