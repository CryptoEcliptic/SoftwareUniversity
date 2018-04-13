using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01HelloName
{
    class Program
    {
        static string NameGreeting(string name)
        {
            return ($"Hello, {name}!");
        }

        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Console.WriteLine(NameGreeting(name));
        }
    }
}
