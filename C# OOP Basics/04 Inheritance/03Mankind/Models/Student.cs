using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03Mankind.Models
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string secondName, string facultyNumber)
            : base(firstName, secondName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            protected set
            {
                var pattern = @"^[a-zA-Z0-9]{5,10}$";

                if (!Regex.IsMatch(value, pattern))
                {
                    Exception ae = new ArgumentException("Invalid faculty number!");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                facultyNumber = value;
            }
        }
      
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.SecondName}");
            sb.AppendLine($"Faculty number: {this.FacultyNumber}");

            return sb.ToString();
        }
    }
}
