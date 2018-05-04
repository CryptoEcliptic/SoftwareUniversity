using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, List<string>> dictionary = new Dictionary<string, List<string>>();
            string input = "";

            while ((input = Console.ReadLine()) != "JOKER")
            {
                string[] array = input.Split(':').ToArray();

                if (!dictionary.ContainsKey(array[0]))
                {
                    List<string> list = array[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    dictionary.Add(array[0], list);
                }
                else
                {
                    List<string> list = array[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var concatList = dictionary[array[0]].Concat(list).Distinct().ToList();
                    dictionary[array[0]] = concatList;
                }
            }

            foreach (var item in dictionary)
            {
                int sum = 0;
                foreach (var card in item.Value.Distinct())
                {
                    int result = 0;
                    switch (card.Substring(0, card.Length - 1))
                    {
                        case "2":
                            result = 2;
                            break;
                        case "3":
                            result = 3;
                            break;
                        case "4":
                            result = 4;
                            break;
                        case "5":
                            result = 5;
                            break;
                        case "6":
                            result = 6;
                            break;
                        case "7":
                            result = 7;
                            break;
                        case "8":
                            result = 8;
                            break;
                        case "9":
                            result = 9;
                            break;
                        case "10":
                            result = 10;
                            break;
                        case "J":
                            result = 11;
                            break;
                        case "Q":
                            result = 12;
                            break;
                        case "K":
                            result = 13;
                            break;
                        case "A":
                            result = 14;
                            break;

                    }
                    switch (card.Substring(card.Length - 1))
                    {
                        case "S":
                            result = result * 4;
                            break;
                        case "H":
                            result = result * 3;
                            break;
                        case "D":
                            result = result * 2;
                            break;
                        case "C":
                            result = result * 1;
                            break;
                    }
                    sum += result;
                }
                Console.WriteLine("{0}: {1}", item.Key, sum);
            }
        }
    }
}
