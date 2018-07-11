using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {
            //4 3 2 1 0
            try
            {
                List<int> inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
                List<int> loserList = new List<int>();

                int lengthSequence = inputNumbers.Count;
                
                while (inputNumbers.Count > 1)
                {
                    for (int i = 0; i < inputNumbers.Count; i++)
                    {
                        if (Math.Abs(loserList.Count - inputNumbers.Count) == 1)
                        {
                            continue;
                        }

                        if (loserList.Contains(i))
                        {
                            continue;
                        }

                        int atackerIndex = i;
                        int target = ValidIndex(inputNumbers[atackerIndex], inputNumbers.Count);
                        int difference = Math.Abs(atackerIndex - target);
                        if (difference == 0)
                        {
                            Console.WriteLine($"{atackerIndex} performed harakiri");
                            loserList.Add(atackerIndex);
                            loserList = loserList.Distinct().ToList();
                        }
                        if (difference != 0 && difference % 2 == 0)
                        {
                            Console.WriteLine($"{atackerIndex} x {target} -> {atackerIndex} wins");
                            loserList.Add(target);
                            loserList = loserList.Distinct().ToList();
                        }
                        if (difference % 2 == 1)
                        {
                            Console.WriteLine($"{atackerIndex} x {target} -> {target} wins");
                            loserList.Add(atackerIndex);
                            loserList = loserList.Distinct().ToList();
                        }   
                    }

                    foreach (var remove in loserList.OrderByDescending(x => x).Distinct())
                    {
                        inputNumbers.RemoveAt(remove);
                    }
                    loserList.Clear();
                }
            }
            catch
            {
     
            }  
        }
        private static int ValidIndex(int index, int lenght)
        {
            if (index >= lenght)
            {
                index = index % lenght;
            }
            return index;
        }
    }
}
