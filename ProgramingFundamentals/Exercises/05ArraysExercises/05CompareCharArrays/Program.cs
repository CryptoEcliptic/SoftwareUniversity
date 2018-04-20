using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstArray = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            char[] secondArray = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            bool isFirstArrayFirst = false;
            int length = Math.Min(firstArray.Length, secondArray.Length);
            for (int i = 0; i < length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    if (firstArray[i] < secondArray[i] )
                    {
                        isFirstArrayFirst = true;
                        break;
                    }
                    else
                    {
                        break;
                       
                    }
                }
            }

            if (isFirstArrayFirst) //Comparisson ASCII
            {
                Console.WriteLine(string.Join("",firstArray));
                Console.WriteLine(string.Join("", secondArray));
            }
            else
            {
                if (firstArray.Length < secondArray.Length) //Comparisson length
                {
                    Console.WriteLine(string.Join("", firstArray));
                    Console.WriteLine(string.Join("", secondArray));
                }
                else
                {
                    Console.WriteLine(string.Join("", secondArray));
                    Console.WriteLine(string.Join("", firstArray));
                }
            }
        }
    }
}
