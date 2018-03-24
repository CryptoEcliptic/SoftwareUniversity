using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06SumOrMultiply
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlNumber = int.Parse(Console.ReadLine());

            int sum = 0;
            int multiply = 0;
            int count = 0;
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 1; j <= 30; j++)
                {
                    for (int k = 1; k <= 30; k++)
                    {
                        if (i < j && j < k)
                        {
                            sum = i + j + k;
                            if (controlNumber == sum)
                            {
                                Console.WriteLine($"{i} + {j} + {k} = {controlNumber}");
                                count++;
                            }
                        }
                        else if (i > j && j > k)
                        {
                            multiply = i * j * k;
                            if (controlNumber == multiply)
                            {
                                Console.WriteLine($"{i} * {j} * {k} = {controlNumber}");
                                count++;
                            }
                        }
                    }
                }
            }
            if (count == 0) //if count = 0 none of the above conditions were met.
            {
                Console.WriteLine("No!");
            }
        }
    }
}
