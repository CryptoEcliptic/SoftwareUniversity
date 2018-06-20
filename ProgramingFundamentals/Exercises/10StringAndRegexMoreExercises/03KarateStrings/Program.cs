using System;
using System.Collections.Generic;
using System.Linq;

namespace _03KarateStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> input = Console.ReadLine().ToCharArray().ToList(); ;
            int strength = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                }
                else
                {
                    if (strength > 0)
                    {
                        input.RemoveAt(i);

                        strength--;
                        i--;
                    }
                }
            }
            Console.WriteLine(string.Join("", input));
        }
    }
}
