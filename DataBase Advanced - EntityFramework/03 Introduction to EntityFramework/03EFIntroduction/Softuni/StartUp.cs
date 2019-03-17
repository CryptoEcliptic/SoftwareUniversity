using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
               
                string allEmployeesInfo = GetEmployeesFullInformation(context);
                Console.WriteLine(allEmployeesInfo);
            }


        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary, e.EmployeeId })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employeesWithSalaries = context.Employees
                .Select(x => new { x.FirstName, x.Salary })
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var e in employeesWithSalaries)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeesFromResAndDev = context.Employees
               .Where(x => x.Department.Name == "Research and Development")
               .Select(x => new { x.FirstName, x.LastName, x.Department.Name, x.Salary, x.EmployeeId })
               .ToList()
               .OrderBy(x => x.Salary)
               .ThenByDescending(x => x.FirstName);

            StringBuilder sb = new StringBuilder();
            foreach (var e in employeesFromResAndDev)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            int townId = 4;
            string addressText = "Vitoshka 15";

            Address address = new Address();
            address.AddressText = addressText;
            address.TownId = townId;
            context.Addresses.Add(address);
            context.SaveChanges();

            var employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            employee.Address = address;
            context.SaveChanges();

            var filteredAddresses = context.Employees
                .Select(x => new { x.AddressId, x.Address.AddressText })
                .ToList()
                .OrderByDescending(x => x.AddressId)
                .Take(10);

            StringBuilder sb = new StringBuilder();
            foreach (var a in filteredAddresses)
            {
                sb.AppendLine(a.AddressText);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                    .Where(x => x.EmployeesProjects
                            .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                     .Select(x => new
                     {
                         eFirstName = x.FirstName,
                         eLastName = x.LastName,
                         mFirstName = x.Manager.FirstName,
                         mLastName = x.Manager.LastName,
                         Projects = x.EmployeesProjects
                            .Select(ep => new
                            {
                                ProjectName = ep.Project.Name,
                                ProjectStartDate = ep.Project.StartDate,
                                ProjectEndDate = ep.Project.EndDate,
                            }).ToList()

                     })
                     .Take(10)
                     .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
               sb.AppendLine($"{e.eFirstName} {e.eLastName} - Manager: {e.mFirstName} {e.mLastName}");

                foreach (var project in e.Projects)
                {
                    string startDate = project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = project.ProjectEndDate != null
                        ? project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                    .Select(a => new
                    {
                        address = a.AddressText,
                        town = a.Town.Name,
                        countOfEmployees = a.Employees.Count()

                    })
                    .OrderByDescending(x => x.countOfEmployees)
                    .ThenBy(x => x.town)
                    .ThenBy(x => x.address)
                    .Take(10)
                    .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.address}, {a.town} - {a.countOfEmployees} employees");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employeeWithProjects = context.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(x => new
                    {
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        jobTitle = x.JobTitle,
                        projects = x.EmployeesProjects
                        .Select(p => new
                        {

                            projectName = p.Project.Name
                        })
                        .OrderBy(p => p.projectName)
                        .ToList()
                    })
                    .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var emp in employeeWithProjects)
            {
                sb.AppendLine($"{emp.firstName} {emp.lastName} - {emp.jobTitle}");

                foreach (var pr in emp.projects)
                {
                    sb.AppendLine(pr.projectName);
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(x => x.Employees.Count())
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    departmentName = x.Name,
                    managerFirstName = x.Manager.FirstName,
                    managerLastName = x.Manager.LastName,
                    employees = x.Employees.Select(e => new
                    {
                        employeeFirstName = e.FirstName,
                        employeeLastName = e.LastName,
                        jobTitle = e.JobTitle
                    })
                    .OrderBy(y => y.employeeFirstName)
                    .ThenBy(y => y.employeeLastName)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.departmentName} - {department.managerFirstName} {department.managerLastName}");

                foreach (var emp in department.employees)
                {
                    sb.AppendLine($"{emp.employeeFirstName} {emp.employeeLastName} - {emp.jobTitle}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Select(p => new {
                    name = p.Name,
                    description = p.Description,
                    startDate = p.StartDate
                })
                .Take(10)
                .ToList()
                .OrderBy(x => x.name);

            StringBuilder sb = new StringBuilder();
            foreach (var project in projects)
            {
                sb.AppendLine(project.name);
                sb.AppendLine(project.description);
                string date = project.startDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                sb.AppendLine(date);
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {

            var emplloyees = context.Employees
                 .Where(x => x.Department.Name == "Engineering"
                          || x.Department.Name == "Tool Design"
                          || x.Department.Name == "Marketing"
                          || x.Department.Name == "Information Services")
                 .Select(e => new
                 {
                     firstName = e.FirstName,
                     lastName = e.LastName,
                     salary = Decimal.Multiply(e.Salary, 1.12m)
                 })
                 .OrderBy(x => x.firstName)
                 .ThenBy(x => x.lastName)
                 .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var emp in emplloyees)
            {
                sb.AppendLine($"{emp.firstName} {emp.lastName} (${emp.salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => EF.Functions.Like(x.FirstName, "sa%"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    position = x.JobTitle,
                    salary = x.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.firstName} {employee.lastName} - {employee.position} - (${employee.salary:f2})");
            }
            return sb.ToString().TrimEnd();

        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectKeys = context.EmployeesProjects.Where(x => x.ProjectId == 2);
            var project = context.Projects.FirstOrDefault(x => x.ProjectId == 2);
            
            context.EmployeesProjects.RemoveRange(projectKeys);
            context.Projects.RemoveRange(project);

            context.SaveChanges();

            var printableProjects = context.Projects.Select(p => p.Name).Take(10);

            StringBuilder sb = new StringBuilder();
            foreach (var pr in printableProjects)
            {
                sb.AppendLine(pr);
            }
            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            Town townForDelete = context.Towns.FirstOrDefault(x => x.Name == "Seattle");

            var addressesFromSeattle = context.Addresses
                .Where(x => x.TownId == townForDelete.TownId)
                .ToList();

            int startAddressCount = addressesFromSeattle.Count;
            
            foreach (var emp in context.Employees)
            {
                foreach (var address in addressesFromSeattle)
                {
                    if (emp.AddressId == address.AddressId)
                    {
                        emp.AddressId = null;
                        emp.Address = null;
                    }
                }
            }

            context.Addresses.RemoveRange(addressesFromSeattle);
            context.Towns.Remove(townForDelete);
            context.SaveChanges();

            int actualCount = context.Addresses
                .Where(x => x.TownId == townForDelete.TownId)
                .ToList().Count;
            int revomedaddressesCount = startAddressCount - actualCount;

            string result = $"{revomedaddressesCount} addresses in Seattle were deleted";
            return result;
        }
    }

}
