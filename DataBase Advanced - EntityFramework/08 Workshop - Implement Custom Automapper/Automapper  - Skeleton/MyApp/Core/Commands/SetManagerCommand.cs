using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System;

namespace MyApp.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly MyCompanyContext context;
        
        public SetManagerCommand(MyCompanyContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            var employee = context.Employees.Find(employeeId);
            var manager = context.Employees.Find(managerId);

            if (employee == null)
            {
                throw new ArgumentNullException(null, $"No employee with Id {employeeId} in the database");
            }

            if (manager == null)
            {
                throw new ArgumentNullException(null, $"No manager with Id {managerId} in the database");
            }

            if (employeeId == managerId)
            {
                throw new ArgumentException("Manager Id could not be equal to Emploiee Id!");
            }

            employee.ManagerId = manager.EmployeeId;
            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName} has joined the team of {manager.FirstName} {manager.LastName}";
        }
    }
}
