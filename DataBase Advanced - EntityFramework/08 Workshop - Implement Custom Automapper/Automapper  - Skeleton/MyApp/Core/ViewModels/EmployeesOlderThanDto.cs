using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.ViewModels
{
    public class EmployeesOlderThanDto
    {
  
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

    }
}
