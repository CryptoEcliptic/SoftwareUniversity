using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01ChooseDrink
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine().ToLower();
            string drink = null;
            if (profession == "athlete")
            {
                drink = "Water";
            }
            else if (profession == "businessman" || profession == "businesswoman")
            {
                drink = "Coffee";
            }
            else if (profession == "softuni student")
            {
                drink = "Beer";
            }
            else
            {
                drink = "Tea";
            }
            Console.WriteLine(drink);
        }
    }
}
