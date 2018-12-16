using AnimalCentre.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string data)
        {
            Console.WriteLine(data);
        }
    }
}
