using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04TrippleSum
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool foundSum = false;

            for (int a = 0; a < numbers.Length; a++)
            {
                for (int b = a + 1; b < numbers.Length; b++)
                {
                    int sum = numbers[a] + numbers[b];
                    if (numbers.Contains(sum))
                    {
                        Console.WriteLine($"{numbers[a]} + {numbers[b]} == {sum}");
                        foundSum = true;
                    }
                }
            }
            if (foundSum == false)
            {
                Console.WriteLine("No");
            }
        }
    }
}
