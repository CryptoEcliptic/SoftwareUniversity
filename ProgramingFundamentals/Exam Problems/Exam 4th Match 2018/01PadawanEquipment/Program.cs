using System;

namespace _01PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double priceSabers = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            double studentCount10 = Math.Ceiling(studentsCount + (studentsCount * 0.1));
            double saberSum = studentCount10 * priceSabers;
            int beltsQuantity = 0;
            for (int i = 1; i <= studentsCount; i++)
            {
                if (i % 6 == 0)
                {
                    continue;
                }
                beltsQuantity += 1;
            }
            double beltSum = beltsQuantity * priceBelt;
            double robeSum = studentsCount * priceRobe;

            double totalSum = saberSum + beltSum + robeSum;
            if (totalSum <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                double difference = totalSum - money;
                Console.WriteLine($"Ivan Cho will need {difference:f2}lv more.");
            }
        }

    }
}
