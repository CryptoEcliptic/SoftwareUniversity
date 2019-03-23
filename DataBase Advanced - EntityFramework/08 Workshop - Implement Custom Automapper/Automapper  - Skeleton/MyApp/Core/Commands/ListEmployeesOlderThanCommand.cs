using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly MyCompanyContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(MyCompanyContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            int ageTreshold = int.Parse(args[0]);
            DateTime currentDate = DateTime.Now;

            var employees = context.Employees
                .Where(x => currentDate.Year - x.BirthDay.Value.Year > ageTreshold)
                .OrderByDescending(x => x.Salary)
                .ToList();

            var emoloyeesDto = mapper.CreateMappedObject<List<EmployeesOlderThanDto>>(employees);
            //TODO Find workaround
            StringBuilder output = new StringBuilder();

            foreach (var employee in emoloyeesDto)
            {
                if (employee.ManagerId == null)
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - Manager: [no manager]");
                }
                else
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - Manager: {employee.Manager.LastName}");
                }
            }
            return output.ToString().TrimEnd();
        }
    }
}
