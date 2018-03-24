using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06TheSongOfTheWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int count = 0;
            int i1 = 0;
            int j1 = 0;
            int k1 = 0;
            int l1 = 0;
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            
                            if (i < j && k > l)
                            {
                                if (i * j + k * l == m)
                                {
                                    count++;
                                    Console.Write($"{i}{j}{k}{l} ");
                                    if (count == 4)
                                    {
                                        i1 = i;
                                        j1 = j;
                                        k1 = k;
                                        l1 = l;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (i1 !=0 && j1!=0 && k1 !=0 && l1 !=0)
            {
                Console.WriteLine($"\nPassword: {i1}{j1}{k1}{l1}");
            }
            if (i1 <= 0)
            {
                Console.WriteLine("\nNo!");
            }
        }
    }
}
