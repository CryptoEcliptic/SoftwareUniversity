using System;
using System.Collections.Generic;
using System.Text;

namespace _01GenericBoxOfString
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
            return $"{Data.GetType().Namespace}.{Data.GetType().Name}: {this.Data}";
        }
    }
}
