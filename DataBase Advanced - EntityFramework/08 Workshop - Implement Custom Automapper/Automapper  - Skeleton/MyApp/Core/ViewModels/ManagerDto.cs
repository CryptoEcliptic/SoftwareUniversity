using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.ViewModels
{
    public class ManagerDto
    {
        public ManagerDto()
        {
            this.Employees = new List<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<EmployeeDto> Employees { get; set; }

        public int Count => this.Employees.Count;
    }
}
