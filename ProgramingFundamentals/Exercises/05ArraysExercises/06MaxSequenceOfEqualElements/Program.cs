using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbersArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int currentLength = 1;
            int maxLength = 1;
            int start = 0;
            int maxStart = 0;
            for (int i = 1; i < inputNumbersArray.Length; i++)
            {
                if (inputNumbersArray[i] == inputNumbersArray[i - 1]) //Compring current element with the previous one.
                {
                    currentLength++;
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength; //maxLength accepts the value of the current length.
                        maxStart = start; 
                    }
                }
                else
                {
                    currentLength = 1;
                    start = i; //start comparing from the current i.
                }
            }
            for (int i = maxStart; i < maxStart + maxLength; i++) //starting loop from the maximal achieved position in the array
            {                                                       // loop continues to maximal achieved position in the array + the length of equal numbers.
                Console.Write(inputNumbersArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
