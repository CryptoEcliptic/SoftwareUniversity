using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Data
{
    public class Configuration
    {
        internal static string ConnectionString => @"Server=NAME-PC\SQLEXPRESS;Database=CarDealer;Integrated Security=True;";
    }
}
