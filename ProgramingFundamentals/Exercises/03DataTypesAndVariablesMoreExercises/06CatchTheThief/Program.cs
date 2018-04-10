using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006CatchTheThief
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeNumber = Console.ReadLine();
            int numbersToEnter = int.Parse(Console.ReadLine());
            long thiefID = long.MinValue;
            for (int i = 0; i < numbersToEnter; i++)
            {
                string enteredNum = Console.ReadLine();
                if (typeNumber == "sbyte")
                {
                    try
                    {
                        long currentID = sbyte.Parse(enteredNum);
                        thiefID = Math.Max(currentID, thiefID);
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (typeNumber == "int")
                {
                    try
                    {
                        long currentID = int.Parse(enteredNum);
                        thiefID = Math.Max(currentID, thiefID);
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (typeNumber == "long")
                {
                    try
                    {
                        long currentID = long.Parse(enteredNum);
                        thiefID = Math.Max(currentID, thiefID);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            Console.WriteLine(thiefID);
        }
    }
}
