using System;
using System.Collections.Generic;
using System.Linq;

namespace _08RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numberCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCars; i++)
            {
                string[] carInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


                string model = carInformation[0];
                int engineSpeed = int.Parse(carInformation[1]);
                int enginePower = int.Parse(carInformation[2]);
                int cargoWeight = int.Parse(carInformation[3]);
                string cargoType = carInformation[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                List<Tire> tires = new List<Tire>();
                AddingTires(carInformation, tires);

                Car currentCar = new Car(model, engine, cargo, tires);
                cars.Add(currentCar);
            }
            string command = Console.ReadLine();


            foreach (var car in cars)
            {
                PrintCars(command, car);

            }
        }

        private static void PrintCars(string command, Car car)
        {
            if (command == "fragile" && car.Cargo.CargoType.Equals("fragile") && car.Tires.Any(x => x.TirePressure < 1))
            {
                Console.WriteLine(car.Model);
            }
            if (command == "flamable" && (car.Cargo.CargoType.Equals("flamable") && car.Engine.EnginePower > 250))
            {
                Console.WriteLine(car.Model);
            }
        }

        private static void AddingTires(string[] carInformation, List<Tire> tires)
        {
            for (int j = 0; j <= 6; j += 2)
            {
                double tirePressure = double.Parse(carInformation[5 + j]);
                int tireAge = int.Parse(carInformation[5 + j + 1]);
                Tire tire = new Tire(tireAge, tirePressure);
                tires.Add(tire);
            }
        }
    }
}
