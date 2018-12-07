using _02VehiclesExtension.Vehicles;
using System;

namespace _02VehiclesExtension
{
    public class Engine
    {
        public void Run()
        {
            string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelCar = double.Parse(carInput[1]);
            double carConsumption = double.Parse(carInput[2]);
            int tankCapacityCar = int.Parse(carInput[3]);
            Car car = new Car(fuelCar, carConsumption, tankCapacityCar);

            string[] truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelTruck = double.Parse(truckInput[1]);
            double truckConsumption = double.Parse(truckInput[2]);
            int tankCapacityTruck = int.Parse(truckInput[3]);
            Truck truck = new Truck(fuelTruck, truckConsumption, tankCapacityTruck);

            string[] busInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelBus = double.Parse(busInput[1]);
            double busConsumption = double.Parse(busInput[2]);
            int tankCapacityBus = int.Parse(busInput[3]);
            Bus bus = new Bus(fuelBus, busConsumption, tankCapacityBus);

            int numberLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberLines; i++)
            {
                try
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

                        else if (typeVehicle == "Bus")
                        {
                            bus.isBusFull = true;
                            bus.Drive(distance);
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

                        else if (typeVehicle == "Bus")
                        {
                            bus.Refuel(fuelQuantity);
                        }
                    }
                    else if (action == "DriveEmpty")
                    {
                        double distance = double.Parse(commands[2]);
                        bus.isBusFull = false;
                        bus.Drive(distance);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");   
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");   
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");   
        }
    }
}
