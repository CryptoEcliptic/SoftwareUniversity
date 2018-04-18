using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] array2 = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            int length = Math.Min(array1.Length, array2.Length);
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (array1[i] == array2[i])
                {
                    counter++;
                }
            }

            array1 = array1.Reverse().ToArray();
            array2 = array2.Reverse().ToArray();

            int reversedCounter = 0;
            for (int i = 0; i < length; i++)
            {
                if (array1[i] == array2[i])
                {
                    reversedCounter++;
                }
            }

            if (counter > reversedCounter)
            {
                Console.WriteLine(counter);
            }
            else
            {
                Console.WriteLine(reversedCounter);
            }
        }
    }
}
