using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int capacityPersons = int.Parse(Console.ReadLine());
            int numberCourses = (int)Math.Ceiling((double)persons / capacityPersons);
            Console.WriteLine(numberCourses);
        }
    }
}
