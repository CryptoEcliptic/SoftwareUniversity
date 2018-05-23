using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber == 0)
            {
                Console.WriteLine('0');
                return;
            }
            int multiply = 0;
            int reminder = 0;
            int num = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                multiply = (firstNumber[i] - '0') * secondNumber + reminder;
                num = multiply % 10;
                if (multiply > 9)
                {
                    reminder = multiply / 10;
                }
                else
                {
                    reminder = 0;
                }
                sb.Append(num);
            }
            if (reminder > 0)
            {
                sb.Append(reminder);
            }
            Console.WriteLine(sb.ToString().TrimEnd('0').ToCharArray().Reverse().ToArray());
        }
    }
}
