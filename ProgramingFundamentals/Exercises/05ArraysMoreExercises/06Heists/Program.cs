using System;
using System.Linq;

namespace _06Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] pricesJewelsGold = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            double priceJewels = pricesJewelsGold[0];
            double priceGold = pricesJewelsGold[1];
            double income = 0;
            double expenses = 0;

            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int countJewels = 0;
            int countGold = 0;

            while (input[0] != "Jail" && input[1] != "Time")
            {
                char[] temp = input[0].ToCharArray(); // Splitting input[0] into char array

                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == '%')
                    {
                        countJewels++;

                    }
                    if (temp[i] == '$')
                    {
                        countGold++;

                    }
                }
                income = (countGold * priceGold) + (countJewels * priceJewels);
                expenses += double.Parse(input[1]);
                input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            if (income >= expenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {income - expenses}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {expenses - income}.");
            }
        }
    }
}
