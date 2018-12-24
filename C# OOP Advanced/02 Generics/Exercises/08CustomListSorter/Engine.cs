using System;
using System.Collections.Generic;
using System.Text;

namespace _08CustomListSorter
{
    public class Engine
    {
        internal CustomList<string> customList;

        public Engine()
        {
            this.customList = new CustomList<string>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commnads = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commnads[0];

                switch (action)
                {
                    case "Add":
                        string element = commnads[1];
                        customList.Add(element);
                        break;

                    case "Remove":
                        int indexToRemove = int.Parse(commnads[1]);
                        customList.Remove(indexToRemove);
                        break;

                    case "Contains":
                        string checkedElement = commnads[1];
                        Console.WriteLine(customList.Contains(checkedElement).ToString());
                        break;

                    case "Swap":
                        int sourceIndex = int.Parse(commnads[1]);
                        int destinationIndex = int.Parse(commnads[2]);
                        customList.Swap(sourceIndex, destinationIndex);
                        break;

                    case "Greater":
                        string greaterElement = commnads[1];
                        Console.WriteLine(customList.CountGreaterThan(greaterElement).ToString());
                        break;

                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;

                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;

                    case "Sort":
                        customList.Sort();
                        break;

                    case "Print":
                        foreach (var el in customList)
                        {
                            Console.WriteLine(el);
                        }
                        break;

                    default:
                        throw new ArgumentException();
                }

                input = Console.ReadLine();
            }
        }
    }
}
