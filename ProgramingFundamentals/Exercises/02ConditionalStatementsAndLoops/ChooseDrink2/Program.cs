using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseDrink2
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;
            string drink = null;
            if (profession == "Athlete")
            {
                drink = "Water";
                price = 0.70 * quantity;
            }
            else if (profession == "Businessman" || profession == "Businesswoman")
            {
                drink = "Coffee";
                price = 1.00 * quantity;
            }
            else if (profession == "SoftUni Student")
            {
                drink = "Beer";
                price = 1.70 * quantity;
            }
            else
            {
                drink = "Tea";
                price = 1.20 * quantity;
            }
            Console.WriteLine($"The {profession} has to pay {price:f2}.");
        }
    }
}
