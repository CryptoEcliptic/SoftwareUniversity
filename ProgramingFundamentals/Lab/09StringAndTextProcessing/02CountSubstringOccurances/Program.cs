using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CountSubstringOccurances
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine().ToLower();
            string searchedWord = Console.ReadLine().ToLower();
            int counter = 0;
            int combinations = inputText.IndexOf(searchedWord);

            while (combinations != -1)
            {
                counter++;
                combinations = inputText.IndexOf(searchedWord, combinations+1);
            }  
                
            Console.WriteLine(counter);
        }
    }
}
