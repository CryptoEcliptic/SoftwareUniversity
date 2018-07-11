using System;
using System.Numerics;

namespace _01Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger snowballValue = -999999999999;
            int snow = 0;
            int time = 0;
            int quality = 0;

            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValueCurrent = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowballValueCurrent > snowballValue)
                {
                    snowballValue = snowballValueCurrent;
                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                }
            }
            Console.WriteLine($"{snow} : {time} = {snowballValue} ({quality})");
        }
    }
}
