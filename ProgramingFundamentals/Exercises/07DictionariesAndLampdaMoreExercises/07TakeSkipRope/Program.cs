using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            char[] text = inputText.ToCharArray();

            List<int> numbersList = new List<int>();
            List<char> nonNumbers = new List<char>();
            NumberChecker(text, numbersList, nonNumbers);

            List<int> skipList = new List<int>();
            List<int> takeList = new List<int>();
            SkipOrTakeElement(numbersList, skipList, takeList);

            string result = null;
            var total = 0;
            for (int index = 0; index < skipList.Count; index++)
            {
                int skipCount = skipList[index];
                int takeCoun = takeList[index];
                result += new string(nonNumbers.Skip(total).Take(takeCoun).ToArray());
                total += skipCount + takeCoun;
            }
            Console.WriteLine(result);
        }
        private static void SkipOrTakeElement(List<int> numbersList, List<int> skipList, List<int> takeList)
        {
            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 1)
                {
                    skipList.Add(numbersList[i]);
                }
                else
                {
                    takeList.Add(numbersList[i]);
                }
            }
        }

        private static void NumberChecker(char[] text, List<int> numbersList, List<char> nonNumbers)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    numbersList.Add(text[i] - 48);
                }
                else
                {
                    nonNumbers.Add(text[i]);
                }
            }
        }
    }
}
