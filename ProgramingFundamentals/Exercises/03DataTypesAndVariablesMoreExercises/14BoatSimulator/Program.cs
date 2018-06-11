using System;
using System.Linq;

namespace _14BoatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());
            int numberLines = int.Parse(Console.ReadLine());

            int speedFirstBoat = 0;
            int speedSecondBoat = 0;
            for (int i = 1; i <= numberLines; i++)
            {
                string input = Console.ReadLine();
                char[] speed = input.ToCharArray(0, input.Length);
                if (input == "UPGRADE")
                {
                    firstBoat += (char)3;
                    secondBoat += (char)3;
                    continue;
                }

                if (i % 2 == 1)
                {
                    speedFirstBoat += speed.Count();

                }

                else if (i % 2 == 0)
                {
                    speedSecondBoat += speed.Count();
                }

                if (speedFirstBoat >= 50)
                {
                    Console.WriteLine(firstBoat);
                    return;
                }

                else if (speedSecondBoat >= 50)
                {
                    Console.WriteLine(secondBoat);
                    return;
                }
            }

            if (speedFirstBoat > speedSecondBoat)
            {
                Console.WriteLine(firstBoat);
            }

            else if (speedSecondBoat > speedFirstBoat)
            {
                Console.WriteLine(secondBoat);
            }
        }
    }
}
