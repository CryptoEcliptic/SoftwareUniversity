using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
   
    public class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                Engine currentEngine = CreateEngine(parameters);
                Cargo currentCargo = CreateCargo(parameters);
                List<Tire> tires = CreateTires(parameters);

                Car currentCar = new Car(model, currentEngine, currentCargo, tires); //Create a car
                cars.Add(currentCar); //Adding car in a list
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static List<Tire> CreateTires(string[] parameters)
        {
            List<Tire> tires = new List<Tire>();
            for (int j = 0; j <= 6; j += 2)
            {
                double tirePressure = double.Parse(parameters[5 + j]);
                int tireAge = int.Parse(parameters[5 + j + 1]);
                Tire tire = new Tire(tirePressure, tireAge);
                tires.Add(tire);
            }

            return tires;
        }

        private static Cargo CreateCargo(string[] parameters)
        {
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            Cargo currentCargo = new Cargo(cargoType, cargoWeight);
            return currentCargo;
        }

        private static Engine CreateEngine(string[] parameters)
        {
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            Engine currentEngine = new Engine(engineSpeed, enginePower);
            return currentEngine;
        }
    }
}
