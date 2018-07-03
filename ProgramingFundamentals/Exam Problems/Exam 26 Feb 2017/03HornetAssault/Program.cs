using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03HornetAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            List<long> hornets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            long minIndex = Math.Min(beehives.Count, hornets.Count);
            long sumHornets = hornets.Sum();


            for (int i = 0; i < minIndex; i++)
            {
                if (i > beehives.Count - 1)
                {
                    break;
                }
                if (hornets.Count == 0) //Important for incorrect input. 6-th test judge fail without that code part
                {
                    break;
                }
                if (beehives.Count == 0) // same, but no test for it in judge
                {
                    break;
                }
                if (sumHornets > beehives[i]) 
                {
                    beehives.RemoveAt(i);
                    i--;
                }
                else if (beehives[i] >= sumHornets)
                {
                    beehives[i] = beehives[i] - sumHornets;
                    if (beehives[i] == 0)
                    {
                        beehives.RemoveAt(i);
                        i--;
                    }
                    hornets.RemoveAt(0);
                    sumHornets = hornets.Sum();
                }
            }
            long sumBees = beehives.Sum();

            if (sumBees > 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else if(sumBees < 1)
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
