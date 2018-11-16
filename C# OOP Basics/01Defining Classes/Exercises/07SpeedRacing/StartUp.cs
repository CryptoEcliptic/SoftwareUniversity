using System;
using System.Collections.Generic;

namespace _07SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] inputCarInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = inputCarInformation[0];
                double fuelAmmount = double.Parse(inputCarInformation[1]);
                double fuelConsumption = double.Parse(inputCarInformation[2]);
                Car currentCar = new Car(model, fuelAmmount, fuelConsumption);
                cars.Add(currentCar);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] driving = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = driving[1];
                double kilometersToDrive = double.Parse(driving[2]);

                foreach (var car in cars)
                {
                    double tempFuel = car.FuelAmount;
                    if (model == car.Model)
                    {
                        CalculateFuelStatus(kilometersToDrive, car, tempFuel);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }

        private static void CalculateFuelStatus(double kilometersToDrive, Car car, double tempFuel)
        {
            tempFuel -= car.FuelConsumption * kilometersToDrive;
            if (tempFuel >= 0)
            {
                car.FuelAmount = tempFuel;
                car.TravelledDistance += kilometersToDrive;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
