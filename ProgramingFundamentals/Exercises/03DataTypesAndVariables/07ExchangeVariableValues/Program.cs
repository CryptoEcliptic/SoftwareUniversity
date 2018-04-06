using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07ExchangeVariableValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            int newA = b;
            int newB = a;
            Console.WriteLine($"Before:\r\na = {a}\r\nb = {b}");
            Console.WriteLine($"After:\r\na = {newA}\r\nb = {newB}");
        }
    }
}
