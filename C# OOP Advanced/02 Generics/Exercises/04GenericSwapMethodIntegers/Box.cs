using System;
using System.Collections.Generic;
using System.Text;

namespace _04GenericSwapMethodIntegers
{

    public class Box<T>
    {
        public Box(List<T> items)
        {
            this.Items = items;
        }
        public List<T> Items { get; set; }


        public void Swap(int sourceIndex, int destinationIndex)
        {
            T temporaryData = this.Items[sourceIndex];
            this.Items[sourceIndex] = this.Items[destinationIndex];
            this.Items[destinationIndex] = temporaryData;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();

        }

    }
}
