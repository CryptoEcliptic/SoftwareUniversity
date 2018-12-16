using AnimalCentre.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
