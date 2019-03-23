using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Employees = new List<Employee>();
        }

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? BirthDay { get; set; }

        public string Address { get; set; }

        [ForeignKey(nameof(Manager))]
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
