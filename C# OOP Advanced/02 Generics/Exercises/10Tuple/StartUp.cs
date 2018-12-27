using System;

namespace _10Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] inputOne = Console.ReadLine().Split();
            Tuple<string, string> firstTupple = new Tuple<string, string>((inputOne[0] + " " + inputOne[1]), inputOne[2]);

            string[] inputTwo = Console.ReadLine().Split();
            Tuple<string, int> secondTupple = new Tuple<string, int>((inputTwo[0]), int.Parse(inputTwo[1]));

            string[] inputThree = Console.ReadLine().Split();
            Tuple<int, double> thirdTupple = new Tuple<int, double>(int.Parse(inputThree[0]), double.Parse(inputThree[1]));

            Console.WriteLine(firstTupple.ToString());
            Console.WriteLine(secondTupple.ToString());
            Console.WriteLine(thirdTupple.ToString());
        }
    }
}
