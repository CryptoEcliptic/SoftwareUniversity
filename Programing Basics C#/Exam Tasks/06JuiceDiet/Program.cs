using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06JuiceDiet
{
    class Program
    {
        static void Main(string[] args)
        {
            int raspberries = int.Parse(Console.ReadLine());
            int strawberries = int.Parse(Console.ReadLine());
            int cherries = int.Parse(Console.ReadLine());
            int juiceLimit = int.Parse(Console.ReadLine());
            double currentJuice = 0;
            double maxJuice = 0;
            int i1 = 0;
            int j1 = 0;
            int k1 = 0;

            for (int i = 0; i <= raspberries; i++)
            {
                for (int j = 0; j <= strawberries; j++)
                {
                    for (int k = 0; k <= cherries; k++)
                    {
                        currentJuice = (i * 4.5) + (j * 7.5) + (k * 15);
                      
                        if (currentJuice <= juiceLimit)
                        {
                            if (currentJuice > maxJuice)
                            {
                                maxJuice = currentJuice;
                                i1 = i;
                                j1 = j;
                                k1 = k;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"{i1} Raspberries, {j1} Strawberries, {k1} Cherries. Juice: {maxJuice} ml.");
        }
    }
}
