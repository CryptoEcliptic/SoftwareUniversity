using _01ListyIterator.Modles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> listIterator = null;
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] arguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = arguments[0];
 
                try
                {
                    switch (command)
                    {
                        case "Create":
                            string[] data = arguments.Skip(1).ToArray();
                            listIterator = new ListyIterator<string>(data);
                            break;

                        case "Move":
                            Console.WriteLine(listIterator.Move().ToString()); 
                            break;

                        case "HasNext":
                            Console.WriteLine(listIterator.HasNext().ToString()); 
                            break;

                        case "Print":
                            listIterator.Print();
                            break;
                            
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}
