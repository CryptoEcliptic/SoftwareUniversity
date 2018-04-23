using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> positiveValues = new List<int>();
            int countNumber = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= 0)
                {
                    positiveValues.Add(numbers[i]);
                    countNumber++;
                }
            }
            positiveValues.Reverse();
            if (countNumber < 1)
            {
                Console.WriteLine("empty");
            }
            Console.WriteLine(string.Join(" ", positiveValues));
            
        }
    }
}
