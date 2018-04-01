using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06NumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int specialNum = int.Parse(Console.ReadLine());
            int controlNum = int.Parse(Console.ReadLine());


            for (int i = n; i >= 1; i--)
            {
                for (int j = m; j >= 1; j--)
                {

                    for (int k = l; k >= 1; k--)
                    {
                        int sum = i * 100 + j * 10 + k;

                        if (sum % 3 == 0)
                        {
                            specialNum += 5;
                        }
                        else if (sum % 10 == 5)
                        {
                            specialNum -= 2;
                        }
                        else if (sum % 2 == 0)
                        {
                            specialNum = specialNum * 2;

                        }
                        if (specialNum >= controlNum)
                        {
                            Console.WriteLine("Yes! Control number was reached! Current special number is {0}.", specialNum);
                            return;
                        }
                    }
                }

            }
            Console.WriteLine("No! {0} is the last reached special number.", specialNum);
        }
    }
}
