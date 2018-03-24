using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Hourglass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string stars = new string('*', 2 * n + 1);
            Console.WriteLine(stars);
            Console.WriteLine(".*{0}*.", new string(' ', 2 * n - 3));

            int @count = 2 * n - 5;
            for (int i = 1; i <= n-2 ; i++)
            {
                int sideDots = i + 1;
                Console.WriteLine("{0}*{1}*{0}", new string('.', sideDots), new string('@', @count));
                @count -= 2;
            }
            Console.WriteLine("{0}*{0}", new string('.', n));
            int lowerCicleDots = n - 1; 
            for (int i = 0; i < n - 2; i++)
            {
                int blanks = i;
                Console.WriteLine("{0}*{1}@{1}*{0}", new string('.', lowerCicleDots), new string(' ', blanks));
                lowerCicleDots--;
            }
            Console.WriteLine(".*{0}*.", new string('@', 2 * n - 3));
            Console.WriteLine(stars);
        }
    }
}
