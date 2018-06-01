using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _08MentorGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of dates")
                {
                    break;
                }

                List<string> usersInput = input.Split(' ', ',').ToList();
                string username = usersInput[0];
                usersInput.RemoveAt(0);
                List<DateTime> dates = new List<DateTime>();
                for (int i = 0; i < usersInput.Count; i++)
                {
                    dates.Add(DateTime.ParseExact(usersInput[i], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
                if (studentsList.Any(x => x.Name == username))
                {
                    Student currentStudent = studentsList.First(x => x.Name == username);
                    currentStudent.AttendanceDates.AddRange(dates);
                }
                else
                {
                    Student student = new Student();
                    student.Name = username;
                    student.AttendanceDates = dates;
                    student.Comments = new List<string>();
                    studentsList.Add(student);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of comments")
                {
                    break;
                }
                string[] commentsInput = input.Split('-');
                string studentName = commentsInput[0];
                string comments = commentsInput[1];
                if (!studentsList.Any(x => x.Name == studentName))
                {
                    continue;
                }
                else if (studentsList.Any(x => x.Name == studentName))
                {
                    Student currentStudent = studentsList.First(x => x.Name == studentName);
                    currentStudent.Comments.Add(comments);
                }

            }
            foreach (var student in studentsList.OrderBy(x => x.Name))
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");
                foreach (var com in student.Comments)
                {
                    Console.WriteLine($"- {com}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in student.AttendanceDates.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy")}");
                }
            }
        }
    }
    class Student
    {
        public List<string> Comments { get; set; }
        public List<DateTime> AttendanceDates { get; set; }
        public string Name { get; set; }
    }
}
