using System;
using System.Collections.Generic;
using System.Text;

namespace _07CustomList
{
    public class Engine
    {
        CustomList<string> customList = new CustomList<string>();

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
                      
                    case "Print":
                        Console.WriteLine(customList.ToString());
                        break;
                }

                input = Console.ReadLine();
            }
        }
  
    }
}
