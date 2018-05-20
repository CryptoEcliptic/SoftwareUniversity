using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = 0;
            char[] arr = input.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                result = arr[i];
                Console.Write("\\u{0:x4}", result);
            }
            Console.WriteLine();
        }
    }
}
