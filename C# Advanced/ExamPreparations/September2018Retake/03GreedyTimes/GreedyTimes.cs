using System;
using System.Collections.Generic;
using System.Linq;

namespace _2017SeptemberRetakeCsharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var bag = new Dictionary<string, Dictionary<string, long>>();
            int count = bag.Count;
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            long currentTotalValue = 0;
            long goldValue = 0;
            long gemValue = 0;
            long cashValue = 0;


            for (int i = 0; i < input.Length - 1; i++)
            {
                string resource = input[i];
                long quantity = long.Parse(input[i + 1]);
                if (currentTotalValue + quantity <= bagCapacity)
                {
                    if (resource.Contains("Gold"))
                    {
                        if (!bag.ContainsKey("Gold"))
                        {
                            bag.Add("Gold", new Dictionary<string, long>());
                            bag["Gold"].Add(resource, quantity);
                            goldValue += quantity;
                        }
                        else
                        {
                            bag["Gold"][resource] += quantity;
                            goldValue += quantity;
                        }
                    }
                    else if ((resource.Contains("Gem") || resource.Contains("gem")) && gemValue + quantity <= goldValue)
                    {
                        if (!bag.ContainsKey("Gem"))
                        {
                            bag.Add("Gem", new Dictionary<string, long>());
                            bag["Gem"].Add(resource, quantity);
                            gemValue += quantity;
                        }
                        else
                        {
                            if (!bag["Gem"].ContainsKey(resource))
                            {
                                bag["Gem"].Add(resource, quantity);
                                gemValue += quantity;
                            }
                            else
                            {
                                bag["Gem"][resource] += quantity;
                                gemValue += quantity;
                            }
                        }
                    }
                    else
                    {
                        
                        if (!bag.ContainsKey("Cash") && resource.Length == 3 && cashValue + quantity <= gemValue)
                        {
                            bag.Add("Cash", new Dictionary<string, long>());
                            bag["Cash"].Add(resource, quantity);
                            cashValue += quantity;
                        }
                        else
                        {
                            if (cashValue + quantity <= gemValue)
                            {
                                if (!bag["Cash"].ContainsKey(resource))
                                {
                                    bag["Cash"].Add(resource, quantity);

                                }
                                else
                                {
                                    bag["Cash"][resource] += quantity;
                                }
                            }
                            
                        }
                    }
                    currentTotalValue = goldValue + cashValue + gemValue;
                }
                i++;
            }

            foreach (var asset in bag.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"<{asset.Key}> ${asset.Value.Values.Sum()}");
                foreach (var item in asset.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}
