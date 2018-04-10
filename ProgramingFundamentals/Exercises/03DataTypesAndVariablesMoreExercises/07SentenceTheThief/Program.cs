using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07SentenceTheThief
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeNumber = Console.ReadLine();
            int numsEntered = int.Parse(Console.ReadLine());
            long thiefID = long.MinValue;

            for (int i = 0; i < numsEntered; i++)
            {
                string enteredNum = Console.ReadLine();

                if (typeNumber == "sbyte")
                {
                    try
                    {
                        long currentNum = sbyte.Parse(enteredNum);
                        thiefID = Math.Max(currentNum, thiefID);
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (typeNumber == "int")
                {
                    try
                    {
                        long currentNum = int.Parse(enteredNum);
                        thiefID = Math.Max(currentNum, thiefID);
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (typeNumber == "long")
                {
                    try
                    {
                        long currentNum = long.Parse(enteredNum);
                        thiefID = Math.Max(currentNum, thiefID);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            double verdict = 0;
            if (thiefID > 0)
            {
                verdict = thiefID / sbyte.MaxValue;
            }
            else if (thiefID < 0)
            {
                verdict = thiefID / sbyte.MinValue;
            }
            if (verdict <= 1)
            {
                Console.WriteLine("Prisoner with id {0} is sentenced to {1} year", thiefID, Math.Ceiling(verdict) + 1);
            }
            else
            {
                Console.WriteLine("Prisoner with id {0} is sentenced to {1} years", thiefID, Math.Ceiling(verdict) + 1);
            }
        }
    }
}
