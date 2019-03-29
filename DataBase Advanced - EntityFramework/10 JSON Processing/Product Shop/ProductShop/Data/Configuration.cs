namespace ProductShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Configuration
    {
        internal static string ConnectionString => @"Server=NAME-PC\SQLEXPRESS;Database=ProductsShop;Integrated Security=True;";
    }
}
