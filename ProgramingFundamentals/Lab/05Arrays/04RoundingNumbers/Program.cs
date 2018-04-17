using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int[] roundNUmbers = new int[inputNumbers.Length] ;

            for (int i = 0; i < inputNumbers.Length; i++)
            {
               
              roundNUmbers[i] = (int)Math.Round(inputNumbers[i], MidpointRounding.AwayFromZero);

              
            }
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                Console.WriteLine($"{inputNumbers[i]} => {roundNUmbers[i]}");
            }

        }
    }
}
