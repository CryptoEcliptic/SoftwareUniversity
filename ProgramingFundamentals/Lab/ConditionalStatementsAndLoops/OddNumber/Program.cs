﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while (n % 2 == 0)
            {
                n = int.Parse(Console.ReadLine());
                Console.WriteLine("Please write an odd number.");
            }
            Console.WriteLine($"The number is: {Math.Abs(n)}");
        }
    }
}
