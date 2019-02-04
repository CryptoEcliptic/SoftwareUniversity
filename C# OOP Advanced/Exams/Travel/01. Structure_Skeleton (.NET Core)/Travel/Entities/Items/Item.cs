using System;
using System.Collections.Generic;
using System.Text;
using Travel.Entities.Items.Contracts;

namespace Travel.Entities.Items
{
    public abstract class Item : IItem
    {
        protected Item(int value)
        {
            this.Value = value;
        }

        public int Value { get; }
    }
}
