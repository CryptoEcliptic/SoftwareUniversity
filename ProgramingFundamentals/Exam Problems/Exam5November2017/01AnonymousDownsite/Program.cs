using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _01AnonymousDownsite
{
    class Program
    {
        static void Main(string[] args) //90Judge
        {
            int numberInputs = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            
            StringBuilder hackedSites = new StringBuilder();
            decimal siteLoss = 0;
            BigInteger securityToken = 0;
            int counter = 0;

            for (int i = 1; i <= numberInputs; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string siteName = input[0];
                decimal siteVisits = int.Parse(input[1]);
                decimal priceVisit = decimal.Parse(input[2]);

                hackedSites.AppendLine(siteName);
                siteLoss += siteVisits * priceVisit;
                counter++;
            }
            securityToken = BigInteger.Pow(securityKey, counter);

            Console.Write(hackedSites);
            Console.WriteLine($"Total Loss: {siteLoss:f20}");
            Console.WriteLine($"Security Token: {securityToken}");

        }
    }
}
