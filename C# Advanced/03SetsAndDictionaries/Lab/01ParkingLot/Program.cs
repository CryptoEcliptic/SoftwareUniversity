using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> parking = new HashSet<string>();

            while (input != "END")
            {
                string[] data = input
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = data[0];
                string plateNumber = data[1];

                if (command == "IN")
                {
                    parking.Add(plateNumber);
                }
                else
                {
                    if (parking.Contains(plateNumber))
                    {
                        parking.Remove(plateNumber);
                    }
                }
                input = Console.ReadLine();
            }
            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            
        }
    }
}
