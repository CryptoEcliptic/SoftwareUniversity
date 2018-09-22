using System;

namespace _08RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Fibonacci(0, 1, 1, number);
        }

        public static void Fibonacci(long a, long b, long counter, int number)
        {
            
            if (counter <= number)
            {
                Fibonacci(b, a + b, counter + 1, number);
            }
            long result = a;
            Console.WriteLine(result);
            Environment.Exit(0);
        }
    }
}
