using _03Mankind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03Mankind.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] studentData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string studentFirstName = studentData[0];
            string studentSecondName = studentData[1];
            string facultyNumber = studentData[2];

            Student currentStudent = new Student(studentFirstName, studentSecondName, facultyNumber);

            string[] workerData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string workerFirstName = workerData[0];
            string workerSecondName = workerData[1];
            double weekSalary = double.Parse(workerData[2]);
            double workHours = double.Parse(workerData[3]);

            Worker currentWorker = new Worker(workerFirstName, workerSecondName, weekSalary, workHours);
            currentWorker.CalculateMoneyPerHour();
            Console.WriteLine(currentStudent.ToString());
            Console.WriteLine(currentWorker.ToString().TrimEnd());
        }
    }
}
