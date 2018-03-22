using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int N1 = n;
            int forthN1 = N1 % 10;
            N1 = N1 / 10;
            int thirdN1 = N1 % 10;
            N1 = N1 / 10;
            int secondN1 = N1 % 10;
            N1 = N1 / 10;
            int firstN1 = N1 % 10;
            int M1 = m;
            int forthM1 = M1 % 10;
            M1 = M1 / 10;
            int thirdM1 = M1 % 10;
            M1 = M1 / 10;
            int secondM1 = M1 % 10;
            M1 = M1 / 10;
            int firstM1 = M1 % 10;

            for (int i = firstN1; i <= firstM1; i++)
            {
                for (int j = secondN1; j <= secondM1; j++)
                {
                    for (int k = thirdN1; k <= thirdM1; k++)
                    {
                        for (int l = forthN1; l <= forthM1; l++)
                        {
                            if (i % 2 == 1 && j % 2 == 1 && k % 2 == 1 && l % 2 == 1)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
