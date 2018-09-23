using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            Stack<string> collections = new Stack<string>();
            collections.Push("");

            for (int i = 0; i < inputLines; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        collections.Push(sb.ToString());
                        string text = input[1];
                        sb.Append(text);
                        break;

                    case 2:
                        collections.Push(sb.ToString());
                        int lengthRemove = int.Parse(input[1]);
                        sb.Remove(sb.Length - lengthRemove, lengthRemove);
                        break;

                    case 3:
                        int indexToPrint = int.Parse(input[1]);
                        Console.WriteLine(sb[indexToPrint - 1]);
                        break;

                    case 4:
                        sb.Clear();
                        sb.Append(collections.Pop());
                        break;
                }
            }
        }
    }
}
