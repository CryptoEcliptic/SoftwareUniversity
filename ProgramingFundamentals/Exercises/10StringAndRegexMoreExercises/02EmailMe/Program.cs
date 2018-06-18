using System;
using System.Linq;

namespace _02EmailMe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputEmail = Console.ReadLine().Split('@').ToArray();
            char[] firstPart = inputEmail[0].ToCharArray();
            char[] secondPart = inputEmail[1].ToCharArray();
            int sumFirst = firstPart.Sum(x => x);
            int sumSecond = secondPart.Sum(x => x);
            int result = sumFirst - sumSecond;

            if (result >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }
    }
}
