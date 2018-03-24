using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06GroupName
{
    class Program
    {
        static void Main(string[] args)
        {
            char capitalLetter = char.Parse(Console.ReadLine());
            char smallLetter1 = char.Parse(Console.ReadLine());
            char smallLetter2 = char.Parse(Console.ReadLine());
            char smallLetter3 = char.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());

            int count = -1;
            for (char i = 'A'; i <= capitalLetter; i++)
            {
                for (char j = 'a'; j <= smallLetter1; j++)
                {
                    for (char k = 'a'; k <= smallLetter2; k++)
                    {
                        for (char l = 'a'; l <= smallLetter3; l++)
                        {
                            for (int m = 0; m <= number; m++)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
