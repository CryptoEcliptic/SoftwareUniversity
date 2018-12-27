using System;

namespace _11Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] inputOne = Console.ReadLine().Split();
            Tuple<string, string, string> firstTupple = new Tuple<string, string, string>((inputOne[0] + " " + inputOne[1]), inputOne[2], inputOne[3]);

            string[] inputTwo = Console.ReadLine().Split();
            bool isDrunk = true;
            if (inputTwo[2] != "drunk")
            {
                isDrunk = false;
            }
            Tuple<string, int, bool> secondTupple = new Tuple<string, int, bool>((inputTwo[0]), int.Parse(inputTwo[1]), isDrunk);

            string[] inputThree = Console.ReadLine().Split();
            Tuple<string, double, string> thirdTupple = new Tuple<string, double, string>(inputThree[0], double.Parse(inputThree[1]),
                inputThree[2]);

            Console.WriteLine(firstTupple.ToString());
            Console.WriteLine(secondTupple.ToString());
            Console.WriteLine(thirdTupple.ToString());
        }
    }
}
