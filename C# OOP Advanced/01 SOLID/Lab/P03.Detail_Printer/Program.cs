using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            string inputEmployee = "Gosho";
            string inputManager = "Pesho";
            string[] docs = { "doc1", "doc2", "doc3" };

            IEmployee first = new Employee(inputEmployee);
            IEmployee second = new Manager(inputManager, docs);
            List<IEmployee> employees = new List<IEmployee>();

            employees.Add(first);
            employees.Add(second);

            DetailsPrinter details = new DetailsPrinter(employees);

            details.PrintDetails();
        }
    }
}
