using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly MyCompanyContext context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(MyCompanyContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            int managerId = int.Parse(args[0]);

            var manager = context.Employees
                .Include(x => x.Employees)
                .Where(x => x.EmployeeId == managerId && x.Employees.Count > 0)
                .FirstOrDefault();

            if (manager == null)
            {
                throw new ArgumentNullException(null, "No such manager exists in the Database!");
            }

            var managerDto = this.mapper.CreateMappedObject<ManagerDto>(manager);

            StringBuilder output = new StringBuilder();

            output.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.Count}");

            foreach (var empl in managerDto.Employees)
            {
                output.AppendLine($"- {empl.FirstName} {empl.LastName} - ${empl.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
