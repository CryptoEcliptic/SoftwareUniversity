using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine()
           .Split(' ')
           .Select(int.Parse)
           .ToList();

            int[] bombNumbers = Console.ReadLine()
           .Split(' ')
           .Select(int.Parse)
           .ToArray();

            int bomb = bombNumbers[0];
            int range = bombNumbers[1];

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                if (inputNumbers[i] == bomb)
                {
                    if (range <= i)
                    {
                        for (int j = i; j >= i - range; j--)
                        {
                            inputNumbers[j] = 0;
                        }
                    }
                    else if (range > i)
                    {
                        for (int j = i; j >= 0; j--)
                        {
                            inputNumbers[j] = 0;
                        }
                    }
                    if (range + i > inputNumbers.Count)
                    {
                        for (int j = i; j < inputNumbers.Count; j++)
                        {
                            inputNumbers[j] = 0;
                        }
                    }
                    else if (range + i <= inputNumbers.Count)
                    {
                        for (int j = i; j <= i + range ; j++)
                        {
                            inputNumbers[j] = 0;
                        }
                    }  
                }
            }
            Console.WriteLine(inputNumbers.Sum());
        }
    }
}
