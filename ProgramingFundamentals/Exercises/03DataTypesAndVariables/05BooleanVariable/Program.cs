using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BooleanVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            bool inputToBoolean = Convert.ToBoolean(Console.ReadLine());
            if (inputToBoolean == true)
            {
                Console.WriteLine("Yes");
            }
            else if (inputToBoolean == false)
            {
                Console.WriteLine("No");
            }

        }
    }
}
