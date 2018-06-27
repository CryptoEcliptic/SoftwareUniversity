using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arrData = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> listData = new List<string>();

            for (int i = 0; i < arrData.Length; i++)
            {
                listData.Add(arrData[i]);
            }

            string input = Console.ReadLine();
 
            while (input != "3:1")
            {
                string[] commandsInput = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commandsInput[0];
                int startIndex = int.Parse(commandsInput[1]);
                int endIndex = int.Parse(commandsInput[2]);

                if (startIndex < 0 || startIndex > listData.Count) //Keeping the index inside the boundaries
                {
                    startIndex = 0;
                }

                if (endIndex > listData.Count - 1 || endIndex < 0) //Keeping the index inside the boundaries
                {
                    endIndex = listData.Count - 1;
                }
                
                if (command == "merge")
                {
                    
                    string word = null; //Variable to save the elements
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        word += listData[i];
                    }
                    listData.RemoveRange(startIndex, endIndex - startIndex + 1); //Removing the unnecesary elements from the main list
                    listData.Insert(startIndex, word); //Adding the concatinated word to the main list at specific index
                }

                else if (command == "divide")
                {
                    List<string> divided = new List<string>(); //Collection to store divided elements
                    string word = listData[int.Parse(commandsInput[1])]; //Element to divide
                    int divide = int.Parse(commandsInput[2]); //Division times
                    listData.RemoveAt(int.Parse(commandsInput[1])); //Removing the divided element from the main list
                    int parts = word.Length / divide; //number particles after division

                    for (int i = 0; i < divide; i++)
                    {
                        if (i == divide - 1)
                        {
                            divided.Add(word.Substring(i * parts)); //adding divided element 
                        }
                        else
                        {
                            divided.Add(word.Substring(i * parts, parts)); // adding divided element index, length
                        }
                        
                    }
                    listData.InsertRange(int.Parse(commandsInput[1]), divided); //Adding the divided collection to the main list
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", listData));
        }
       
    }
}
