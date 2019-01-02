using System;
using System.Linq;

namespace _04Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(input);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
