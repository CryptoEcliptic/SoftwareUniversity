using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string inputText = Console.ReadLine();

            while (inputText != "Even" && inputText != "Odd")
            {

                string[] commands = inputText.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                if (commands[0] == "Delete")
                {
                    int numberToDelete = int.Parse(commands[1]);
                    for (int i = 0; i < inputNumbers.Count; i++)
                    {
                        inputNumbers.Remove(numberToDelete);
                    }
                }
                else if (commands[0] == "Insert")
                {
                    int element = int.Parse(commands[1]);
                    int position = int.Parse(commands[2]);

                    inputNumbers.Insert(position, element);
                }
                inputText = Console.ReadLine();
            }
            if (inputText == "Even")
            {
                for (int i = 0; i < inputNumbers.Count; i++)
                {
                    if (inputNumbers[i] % 2 == 0)
                    {
                        Console.Write(inputNumbers[i] + " ");
                    }
                }
                Console.WriteLine();  
            }
            else if (inputText == "Odd")
            {
                for (int i = 0; i < inputNumbers.Count; i++)
                {
                    if (inputNumbers[i] % 2 == 1)
                    {
                        Console.Write(inputNumbers[i] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
