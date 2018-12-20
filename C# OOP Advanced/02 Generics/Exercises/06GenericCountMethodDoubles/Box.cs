using System;
using System.Collections.Generic;
using System.Text;

namespace _06GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable<T>
    {
        public Box() { }


        public void CountGreaterElements(List<T> items, T itemToCompare)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException();
            }
            if (itemToCompare.Equals(default(T)))
            {
                throw new InvalidOperationException();
            }

            int counter = 0;
            foreach (var item in items)
            {
                if (item.CompareTo(itemToCompare) > 0) //IComparable for comparing T elements 
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
