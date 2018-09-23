using System;
using System.Collections.Generic;
using System.Linq;

namespace _11PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int plantsCount = int.Parse(Console.ReadLine());

            int[] plants = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
          
            int[] days = new int[plantsCount];
            Stack<int> previousPlant = new Stack<int>();

            previousPlant.Push(0); //First plant will live in each case. So we put its index

            for (int i = 1; i < plants.Length; i++) //Lop starts from 1 because we've already put first plant in the stack.
            {
                int currentDay = 0;
                while (previousPlant.Count() > 0 && plants[previousPlant.Peek()] >= plants[i])
                {
                    currentDay = Math.Max(currentDay, days[previousPlant.Pop()]);
                }
                if (previousPlant.Count > 0)
                {
                    days[i] = currentDay + 1;
                }
                previousPlant.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}
