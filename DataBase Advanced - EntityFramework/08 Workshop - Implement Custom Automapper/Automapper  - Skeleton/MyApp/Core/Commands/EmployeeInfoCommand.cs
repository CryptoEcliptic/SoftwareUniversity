using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;

namespace MyApp.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly MyCompanyContext context;
        private readonly Mapper mapper;

        public EmployeeInfoCommand(MyCompanyContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException(null, $"Employee with Id {employeeId} does not exist!");
            }

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            return $"{employeeDto.EmployeeId} - {employeeDto.FirstName} {employeeDto.LastName} -  ${employeeDto.Salary:f2}";
        }
    }
}
