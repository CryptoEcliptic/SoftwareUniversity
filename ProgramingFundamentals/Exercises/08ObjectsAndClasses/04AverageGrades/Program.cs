using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> studentClass = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();
                Student studentInfo = new Student();
                studentInfo.Name = input[0];
                input.RemoveAt(0);
                studentInfo.Grades = input.Select(double.Parse).ToList();
                studentClass.Add(studentInfo);
            }
            foreach (var pair in studentClass.Where(x => x.Average >= 5).OrderBy(x => x.Name).ThenByDescending(x => x.Average))
            {
                Console.WriteLine($"{pair.Name} -> {pair.Average:f2}");
            }
        }
    }
}
