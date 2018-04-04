using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05SpecialNUmbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int num = 1; num <= n; num++)
            {
                int sum = 0;
                int digit = num;
                while (digit > 0)
                {
                    sum += digit % 10;
                    digit = digit / 10;
                }
                bool specialNumber = (sum == 5 || sum == 7 || sum == 11);
                Console.WriteLine($"{num} -> {specialNumber}");
            }
        }
    }
}
