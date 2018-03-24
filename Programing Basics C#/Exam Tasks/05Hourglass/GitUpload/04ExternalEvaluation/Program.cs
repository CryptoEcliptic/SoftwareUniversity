using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04ExternalEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            double poorMark = 0;
            double satisfactoryMark = 0;
            double goodMark = 0;
            double veryGoodMark = 0;
            double excellentMark = 0;

            for (int i = 1; i <= numberOfStudents; i++)
            {
                double studentPoints = double.Parse(Console.ReadLine());
                if (studentPoints >= 76.5)
                {
                    excellentMark++;
                }
                else if (studentPoints >= 58.5)
                {
                    veryGoodMark++;
                }
                else if (studentPoints >= 40.5)
                {
                    goodMark++;
                }
                else if (studentPoints >= 22.5)
                {
                    satisfactoryMark++;
                }
                else if (studentPoints < 22.5)
                {
                    poorMark++;
                }
            }
            Console.WriteLine("{0:f2}% poor marks", (poorMark / numberOfStudents) * 100);
            Console.WriteLine("{0:f2}% satisfactory marks", (satisfactoryMark / numberOfStudents) * 100);
            Console.WriteLine("{0:f2}% good marks", (goodMark / numberOfStudents) * 100);
            Console.WriteLine("{0:f2}% very good marks", (veryGoodMark / numberOfStudents) * 100);
            Console.WriteLine("{0:f2}% excellent marks", (excellentMark / numberOfStudents) * 100);
        }
    }
}
