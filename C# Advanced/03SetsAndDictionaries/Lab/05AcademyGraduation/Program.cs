using System;
using System.Collections.Generic;
using System.Linq;

namespace _04AcademyGraduation
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < number; i++)
            {
                string[] studentData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string studentName = studentData[0];
                double studentGrade = double.Parse(studentData[1]);

                if (!students.ContainsKey(studentName))
                {
                    List<double> grades = new List<double>();
                    grades.Add(studentGrade);
                    students.Add(studentName, grades);
                }
                else
                {
                    if (students.ContainsKey(studentName))
                    {
                        students[studentName].Add(studentGrade);
                    }
                }
            }
            foreach (var student in students.OrderByDescending(x => x.Value.Average()))
            {
                Console.Write($"{student.Key} -> "); 
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
               
                
            }
        }
    }
}
