using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
            string commands = Console.ReadLine(); //Read commands as a text.

            while (commands != "print")
            {
             string[] actions = commands.Split(' ').ToArray(); //Turn the command into an array with different elements ("add 1, 4")
                if (actions[0] == "add")
                {
                    int index = int.Parse(actions[1]);
                    int element = int.Parse(actions[2]);
                    inputNumbers.Insert(index, element); //Adding element in a specified index.
                }
                if (actions[0] == "addMany")
                {
                    int index = int.Parse(actions[1]);
                    List<int> elements = new List<int>();
                    for (int i = 2; i < actions.Length; i++)
                    {
                        elements.Add(int.Parse(actions[i]));
                    }
                    inputNumbers.InsertRange(index, elements); //Adding multiple elements
                }
                if (actions[0] == "contains")
                {
                    int element = int.Parse(actions[1]);
                    Console.WriteLine(inputNumbers.IndexOf(element)); //Searches the element and returns to the zero based index.
                }
                if (actions[0] == "remove")
                {
                    int index = int.Parse(actions[1]);
                    inputNumbers.RemoveAt(index);
                }
                if (actions[0] == "shift")
                {
                    int rotations = int.Parse(actions[1]);
                    for (int i = 0; i < rotations; i++)
                    {
                        inputNumbers.Add(inputNumbers[0]); // adding zero element to the end of the list
                        inputNumbers.RemoveAt(0); //removing the zero element. Then first element becomes zero element
                    }
                }
                if (actions[0] == "sumPairs")
                {
                    for (int i = 0; i < inputNumbers.Count - 1; i++)
                    {
                        inputNumbers[i] = inputNumbers[i] + inputNumbers[i + 1];
                        inputNumbers.RemoveAt(i + 1);
                    }
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ", inputNumbers) + "]");
        }
    }
}
