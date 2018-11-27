using System;
using System.Text;

namespace _03Mankind.Models
{
    public class Worker : Human
    {
        private double weekSalary;
        private double workHours;

        public Worker(string firstName, string secondName, double weekSalary, double hours) 
            : base(firstName, secondName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHours = hours;
        }

        public double WorkHours
        {
            get { return workHours; }

            protected set
            {
                if (value < 1 || value > 12)
                {
                    Exception ae = new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                workHours = value;
            }
        }

        public double WeekSalary
        {
            get { return weekSalary; }
            protected set
            {
                if (value <= 10)
                {
                    Exception ae = new ArgumentException("Expected value mismatch! Argument: weekSalary");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                weekSalary = value;
            }
        }

        public double hourPayment = 0;

        public double CalculateMoneyPerHour()
        {
            double totalHoursPerWeek = workHours * 5;
            hourPayment = weekSalary / (double)totalHoursPerWeek;

            return hourPayment;
        }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.SecondName}");
            sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
            sb.AppendLine($"Hours per day: {this.WorkHours:f2}");
            sb.AppendLine($"Salary per hour: {this.hourPayment:f2}");

            return sb.ToString();
        }
    }
}
