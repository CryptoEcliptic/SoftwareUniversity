using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string packageType = Console.ReadLine();
            double packagePrice = 0;
            double hallPrice = 0;
            string hall = null;
            if (groupSize > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            if (packageType == "Normal")
            {
                packagePrice = 500;
                if (groupSize <= 50)
                {
                    hall = "Small Hall";
                    hallPrice = 2500;
                }
                else if (groupSize > 50 && groupSize <= 100)
                {
                    hall = "Terrace";
                    hallPrice = 5000;
                }
                else if (groupSize > 100 && groupSize <= 120)
                {
                    hall = "Great Hall";
                    hallPrice = 7500;
                }
            }
            else if (packageType == "Gold")
            {
                packagePrice = 750;
                if (groupSize <= 50)
                {
                    hall = "Small Hall";
                    hallPrice = 2500;
                }
                else if (groupSize > 50 && groupSize <= 100)
                {
                    hall = "Terrace";
                    hallPrice = 5000;
                }
                else if (groupSize > 100 && groupSize <= 120)
                {
                    hall = "Great Hall";
                    hallPrice = 7500;
                }
            }
            else if (packageType == "Platinum")
            {
                packagePrice = 1000;
                if (groupSize <= 50)
                {
                    hall = "Small Hall";
                    hallPrice = 2500;
                }
                else if (groupSize > 50 && groupSize <= 100)
                {
                    hall = "Terrace";
                    hallPrice = 5000;
                }
                else if (groupSize > 100 && groupSize <= 120)
                {
                    hall = "Great Hall";
                    hallPrice = 7500;
                }
            }
            double priceBeforeDiscount = packagePrice + hallPrice;
            double priceAfterDiscount = 0;
            if (packageType == "Normal") priceAfterDiscount = priceBeforeDiscount * 0.95;
            if (packageType == "Gold") priceAfterDiscount = priceBeforeDiscount * 0.90;
            if (packageType == "Platinum") priceAfterDiscount = priceBeforeDiscount * 0.85;

            double pricePerPerson = priceAfterDiscount / groupSize;
            Console.WriteLine($"We can offer you the {hall}");
            Console.WriteLine($"The price per person is {pricePerPerson:f2}$");
        }
    }
}
