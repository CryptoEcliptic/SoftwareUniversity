using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04GSGO
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberItemsToBuy = int.Parse(Console.ReadLine());
            double moneyAvailable = double.Parse(Console.ReadLine());
            double moneyUsed = 0;

            if (numberItemsToBuy > 7)
            {
                Console.WriteLine("Sorry, you can't carry so many things!");
                return;
            }
            for (int i = 1; i <= numberItemsToBuy; i++)
            {
                string typeWeapon = Console.ReadLine();
                if (typeWeapon == "ak47")
                {
                    moneyUsed += 2700;
                }
                else if (typeWeapon == "awp")
                {
                    moneyUsed += 4750;
                }
                else if (typeWeapon == "sg553")
                {
                    moneyUsed += 3500; 
                }
                else if (typeWeapon == "grenade")
                {
                    moneyUsed += 300;
                }
                else if (typeWeapon == "flash")
                {
                    moneyUsed += 250;
                }
                else if (typeWeapon == "glock")
                {
                    moneyUsed += 500;
                }
                else if (typeWeapon == "bazooka")
                {
                    moneyUsed += 5600;
                }
            }
            if (moneyUsed > moneyAvailable)
            {
                double moneyDifference = Math.Abs(moneyAvailable - moneyUsed);
                Console.WriteLine($"Not enough money! You need {moneyDifference} more money.");
            }
            else
            {
                Console.WriteLine($"You bought all {numberItemsToBuy} items! Get to work and defeat the bomb!");
            }

        }
    }
}
