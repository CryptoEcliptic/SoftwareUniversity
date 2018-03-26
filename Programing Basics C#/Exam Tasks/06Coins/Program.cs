using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal changeMoney = decimal.Parse(Console.ReadLine());
            int coins = 0;

            if (changeMoney >= 2)
            {
                coins = coins + (int)Math.Floor(changeMoney / 2);
                changeMoney %= 2;
            }
            if (changeMoney >= 1)
            {
                coins++;
                changeMoney -= 1;
            }
            if (changeMoney >= 0.50m)
            {
                coins++;
                changeMoney -= 0.50m;
            }
            if (changeMoney >= 0.20m)
            {
                coins++;
                changeMoney -= 0.20m;
            }
            if (changeMoney >= 0.10m)
            {
                coins++;
                changeMoney -= 0.10m;
            }
            if (changeMoney >= 0.05m)
            {
                coins++;
                changeMoney -= 0.05m;
            }
            if (changeMoney >= 0.02m)
            {
                coins++;
                changeMoney -= 0.02m;
            }
            if (changeMoney >= 0.01m)
            {
                coins++;
                changeMoney -= 0.01m;
            }
            Console.WriteLine(coins);
        }
    }
}
