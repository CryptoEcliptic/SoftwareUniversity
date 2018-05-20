using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string firstWord = input[0];
            string secondWord = input[1];
            int multiplier = 0;
            int result = 0;
            var minimum = Math.Min(firstWord.Length, secondWord.Length);
            var maximum = Math.Max(firstWord.Length, secondWord.Length);
            
            for (int i = 0; i <minimum; i++)
            {
                multiplier += firstWord[i] * secondWord[i];
            }

            for (int i = minimum; i < maximum; i++)
            {
                try
                {
                    result += firstWord[i];
                }
                catch
                {
                    result += secondWord[i];
                }               
             }
            result = result + multiplier;
            Console.WriteLine(result);
        }
    }
}
