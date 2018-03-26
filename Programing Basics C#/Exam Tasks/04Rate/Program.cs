using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Rate
{
    class Program
    {
        static void Main(string[] args)
        {
            double startAmount = double.Parse(Console.ReadLine());
            int numberMonths = int.Parse(Console.ReadLine());
            double simpleSum = startAmount;
            double complexSum = startAmount;

            for (int i = 1; i <= numberMonths;  i++)
            {
                simpleSum = simpleSum + (startAmount * 0.03);
                complexSum = complexSum + (complexSum * 0.027);
            }
            Console.WriteLine($"Simple interest rate: {simpleSum:f2} lv.");
            Console.WriteLine($"Complex interest rate: {complexSum:f2} lv.");
            double difference = Math.Abs(simpleSum - complexSum);
            if (simpleSum > complexSum)
            {
                Console.WriteLine($"Choose a simple interest rate. You will win {difference:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Choose a complex interest rate. You will win {difference:f2} lv.");
            }
        }
    }
}
