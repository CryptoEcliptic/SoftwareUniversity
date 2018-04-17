using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07SomOfArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            for (int i = 0; i < Math.Max(array1.Length, array2.Length); i++)
            {
                int sum = array1[i % array1.Length] + array2[i % array2.Length]; //taking first element as next one after the last one
                Console.Write($"{sum} ");
            }
            Console.WriteLine();
        }
    }
}
