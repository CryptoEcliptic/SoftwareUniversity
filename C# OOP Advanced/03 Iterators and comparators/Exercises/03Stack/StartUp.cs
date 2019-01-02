using System;
using System.Linq;

namespace _03Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CustomStack<string> customStack = new CustomStack<string>();

            while (input != "END")
            {
                string[] arguments = input.Split(new char[] {' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = arguments[0];

                switch (command)
                {
                    case "Push":
                        string[] elements = arguments.Skip(1).ToArray();

                        foreach (var element in elements)
                        {
                            customStack.Push(element);
                        }
                        break;

                    case "Pop":
                        try
                        {
                            customStack.Pop();
                        }
                        catch (InvalidOperationException oe)
                        {
                            Console.WriteLine(oe.Message);
                        }
                        break;

                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, customStack));
            Console.WriteLine(string.Join(Environment.NewLine, customStack));
        }
    }
}
