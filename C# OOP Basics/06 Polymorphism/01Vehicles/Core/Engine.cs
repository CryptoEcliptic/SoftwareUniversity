using _01Vehicles.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {

            string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelCar = double.Parse(carInput[1]);
            double carConsumption = double.Parse(carInput[2]);
            Car car = new Car(fuelCar, carConsumption);

            string[] truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelTruck = double.Parse(truckInput[1]);
            double truckConsumption = double.Parse(truckInput[2]);
            Truck truck = new Truck(fuelTruck, truckConsumption);

            int numberLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberLines; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string typeVehicle = commands[1];

                if (action == "Drive")
                {
                    double distance = double.Parse(commands[2]);

                    if (typeVehicle == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (typeVehicle == "Truck")
                    {
                        truck.Drive(distance);
                    }
                }
                else if (action == "Refuel")
                {
                    double fuelQuantity = double.Parse(commands[2]);
                    if (typeVehicle == "Car")
                    {
                        car.Refuel(fuelQuantity);
                    }
                    else if (typeVehicle == "Truck")
                    {
                        truck.Refuel(fuelQuantity);
                    }
                }     
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");   
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");   
        }
    }
}
