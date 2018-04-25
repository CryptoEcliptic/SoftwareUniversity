using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SearchForNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToList();
            int[] arrayNumbers = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();

            List<int> takenNumbers = new List<int>();
            int numbersToTake = arrayNumbers[0];
            int numbersToDelete = arrayNumbers[1];
            
            for (int i = 0; i < numbersToTake; i++)
            {
                takenNumbers.Add(inputNumbers[i]);
            }

            for (int i = 0; i < numbersToDelete; i++)
            {
                takenNumbers.RemoveAt(0);
            }

            int searchedNumber = arrayNumbers[2];
            
            if (takenNumbers.Contains(searchedNumber))
            {
            Console.WriteLine("YES!");       
            }
            else
            {
            Console.WriteLine("NO!");
            }     
        }
    }
}
