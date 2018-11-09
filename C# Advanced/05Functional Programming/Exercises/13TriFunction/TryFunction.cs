using System;
using System.Linq;

namespace _13TriFunction
{
    class TryFunction
    {
        static void Main(string[] args)
        {
         
            int refNumber = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<int, int, bool> functionLettersValue = (int name, int value) => name >= value;

            foreach (var name in names)
            {
                char[] nameAsChar = name.ToCharArray();

                int sumLetters = 0;
                foreach (var letter in nameAsChar)
                {
                    sumLetters += letter;
                }
                if (functionLettersValue(sumLetters, refNumber))
                {
                    Console.WriteLine(name);
                    break;
                }
            }

        }
    }
}
