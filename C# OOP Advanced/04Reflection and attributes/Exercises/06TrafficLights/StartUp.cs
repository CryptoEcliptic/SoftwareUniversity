using System;
using System.Collections.Generic;
using System.Text;

namespace _06TrafficLights
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int numberRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberRotations; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == "Red")
                    {
                        input[j] = "Green";
                    }
                    else if (input[j] == "Green")
                    {
                        input[j] = "Yellow";
                    }
                    else if (input[j] == "Yellow")
                    {
                        input[j] = "Red";
                    }
                }
                Console.WriteLine(string.Join(" ", input));
            }
        }
    }
}
