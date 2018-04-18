using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08CondenseArrayToNymber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
         
            while (nums.Length > 1)
            {
                int[] condensedNumbers = new int[nums.Length - 1];

                for (int i = 0; i < nums.Length - 1; i++)
                {
                    condensedNumbers[i] = nums[i] + nums[i + 1];
                }
                nums = condensedNumbers;
            }
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
        }
    }
}
