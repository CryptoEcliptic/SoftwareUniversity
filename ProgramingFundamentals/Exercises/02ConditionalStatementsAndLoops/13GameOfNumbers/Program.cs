using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;
            for (int i = startNumber; i <= endNumber; i++)
            {
                for (int j = startNumber; j <= endNumber; j++)
                {
                    sum = i + j;
                    count++;
                    if (sum == magicNumber)
                    {
                        Console.WriteLine($"Number found! {j} + {i} = {sum}");
                        return;
                    }

                }
            }
            Console.WriteLine($"{count} combinations - neither equals {magicNumber}");
        }
    }
}
