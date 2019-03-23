using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly MyCompanyContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(MyCompanyContext context, Mapper mapper)
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

            var employeeDto = this.mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee);

            string formattedBirthDate = ((DateTime)employeeDto.BirthDay).ToString("dd-MM-yyyy");

            StringBuilder output = new StringBuilder();
            output.AppendLine($"ID: {employeeDto.EmployeeId} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}");
            output.AppendLine($"Birthday: {formattedBirthDate}");
            output.AppendLine($"Address: {employeeDto.Address}");

            return output.ToString().TrimEnd();
        }
    }
}
