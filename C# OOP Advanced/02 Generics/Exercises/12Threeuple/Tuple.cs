using System;
using System.Collections.Generic;
using System.Text;

namespace _11Threeuple
{
    public class Tuple<T, U, P>
    {
        public Tuple(T itemOne, U ItemTwo, P itemThree)
        {
            this.ItemOne = itemOne;
            this.ItemTwo = ItemTwo;
            this.ItemThree = itemThree;
        }

        public T ItemOne { get; protected set; }
        public U ItemTwo { get; protected set; }
        public P ItemThree { get; protected set; }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo} -> {this.ItemThree}";
        }
    }
}
