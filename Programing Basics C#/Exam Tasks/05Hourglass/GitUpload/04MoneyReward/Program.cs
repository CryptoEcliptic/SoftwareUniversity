using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04MoneyReward
{
    class Program
    {
        static void Main(string[] args)
        {
            int projectParts = int.Parse(Console.ReadLine());
            double moneyPerPoint = double.Parse(Console.ReadLine());
            int sumpoints = 0;
            for (int i = 1; i <= projectParts; i++)
            {
                int points = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    sumpoints += points * 2; 
                }
                else
                {
                    sumpoints += points;
                }
            }
            double reward = moneyPerPoint * sumpoints;
            Console.WriteLine($"The project prize was {reward:f2} lv.");
        }
    }
}
