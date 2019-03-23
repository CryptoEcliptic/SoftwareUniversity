using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System;
using System.Globalization;

namespace MyApp.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly MyCompanyContext context;
       
        public SetBirthdayCommand(MyCompanyContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            DateTime birthday = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var employee = this.context.Employees.Find(id);

            if (employee == null)
            {
                throw new ArgumentNullException(null, $"No employee with id {id}!");
            }

            employee.BirthDay = birthday;
            context.SaveChanges();

            return $"Successfully updated birthday of {employee.FirstName} {employee.LastName}";
        }
    }
}
