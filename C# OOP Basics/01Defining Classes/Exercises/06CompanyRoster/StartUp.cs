using System;
using System.Collections.Generic;
using System.Linq;

namespace _06CompanyRoster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Employee> employeesDatabase = new List<Employee>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string employeeName = inputData[0];
                decimal salary = decimal.Parse(inputData[1]);
                string position = inputData[2];
                string department = inputData[3];

                Employee employee = new Employee(employeeName, salary, position, department);

                if (inputData.Length == 5)
                {
                    if (int.TryParse(inputData[4], out int result))
                    {
                        employee.Age = result;
                    }
                    else if (inputData[4].Contains('@'))
                    {
                        employee.Email = inputData[4];
                    }  
                }
                if (inputData.Length == 6)
                {
                    employee.Email = inputData[4];
                    employee.Age = int.Parse(inputData[5]);
                }
                employeesDatabase.Add(employee);
            }
            var highestSalaryDepartment = employeesDatabase
                .GroupBy(x => x.Department)
                .OrderByDescending(x => x.Average(y => y.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {highestSalaryDepartment.Key}");
            foreach (var person in highestSalaryDepartment.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{person.Name} {person.Salary:f2} {person.Email} {person.Age}");
            }
        }
    }
}
