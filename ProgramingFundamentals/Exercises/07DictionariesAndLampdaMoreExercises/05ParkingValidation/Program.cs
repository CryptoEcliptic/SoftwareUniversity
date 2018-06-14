using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05ParkingValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingData = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] carInput = Console.ReadLine().Split(' ').ToArray();

                if (carInput[0] == "register")
                {
                    string driver = carInput[1];
                    string carNumber = carInput[2];

                    if (parkingData.ContainsKey(driver))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingData[driver]}");

                    }
                    else if (parkingData.ContainsValue(carNumber))
                    {
                        Console.WriteLine($"ERROR: license plate {carNumber} is busy");
                    }
                    else if (!parkingData.ContainsKey(driver))
                    {
                        bool licenseIsValid = IsValid(carNumber);
                        if (!licenseIsValid)
                        {
                            Console.WriteLine($"ERROR: invalid license plate {carNumber}");
                            continue;
                        }
                        if (!parkingData.ContainsValue(carNumber))
                        {
                            Console.WriteLine($"{driver} registered {carNumber} successfully");
                            parkingData.Add(driver, carNumber);
                        }
                    }
                }
                else if (carInput[0] == "unregister")
                {
                    string driverToRemove = carInput[1];
                    if (!parkingData.ContainsKey(driverToRemove))
                    {
                        Console.WriteLine($"ERROR: user {driverToRemove} not found");
                    }
                    else if (parkingData.ContainsKey(driverToRemove))
                    {
                        Console.WriteLine($"user {driverToRemove} unregistered successfully");
                        parkingData.Remove(driverToRemove);
                    }
                }
            }
            foreach (var car in parkingData)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
        private static bool IsValid(string license)
        {
            string pattern = "([A-Z]{2})([0-9]{4})([A-Z]{2})";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(license);
            return match.Success;
        }
    }
}
