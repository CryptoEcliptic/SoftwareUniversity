using System;
using System.Collections.Generic;
using System.Text;

namespace _02GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T inputData)
        {
            this.Data = inputData;
        }

        public T Data { get; set; }
        public override string ToString()
        {
            return $"{Data.GetType().FullName}: {this.Data}";
        }
    }
}
