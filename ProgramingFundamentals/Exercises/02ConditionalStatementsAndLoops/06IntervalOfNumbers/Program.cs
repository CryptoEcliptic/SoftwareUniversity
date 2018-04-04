using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06IntervalOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int smallerNum = 0;
            int biggerNum = 0;
            if (start < end)
            {
                smallerNum = start;
                biggerNum = end;
            }
            else if (start > end)
            {
                biggerNum = start;
                smallerNum = end;
            }
            for (int counter = smallerNum; counter <= biggerNum; counter++)
            {
                Console.WriteLine(counter);
            }
        }
    }
}
