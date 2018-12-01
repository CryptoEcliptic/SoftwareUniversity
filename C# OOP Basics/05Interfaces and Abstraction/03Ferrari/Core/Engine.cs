using System;
using System.Collections.Generic;
using System.Text;

namespace _03Ferrari.Core
{
    public class Engine
    {
        public void Run()
        {
            string driverName = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari.ToString());
        }
    }
}
