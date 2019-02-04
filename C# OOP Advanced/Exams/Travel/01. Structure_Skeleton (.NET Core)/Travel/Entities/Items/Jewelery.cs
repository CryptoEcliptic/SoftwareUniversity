using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Items
{
    public class Jewelery : Item
    {
        private const int Cost = 300;

        public Jewelery() 
            : base(Cost)
        {
        }
    }
}
