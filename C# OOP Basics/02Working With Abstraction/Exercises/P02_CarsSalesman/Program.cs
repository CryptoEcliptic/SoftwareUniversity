using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{

    public class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                CreatingEngines(engines, parameters);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                CreatingCars(cars, engines, parameters);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void CreatingCars(List<Car> cars, List<Engine> engines, string[] parameters)
        {
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            int weight = -1;
            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                Car currentCar = new Car();
                currentCar.Model = model;
                currentCar.Engine = engine;
                currentCar.Weight = weight;
                cars.Add(currentCar);
            }
            else if (parameters.Length == 3)
            {
                string color = parameters[2];
                Car currentCar = new Car();
                currentCar.Model = model;
                currentCar.Engine = engine;
                currentCar.Color = color;
                cars.Add(currentCar);
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                cars.Add(new Car(model, engine, int.Parse(parameters[2]), color));
            }
            else
            {
                Car currentCar = new Car();
                currentCar.Model = model;
                currentCar.Engine = engine;
                cars.Add(currentCar);
            }
        }

        private static void CreatingEngines(List<Engine> engines, string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            int displacement = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {
                Engine engine = new Engine();
                engine.Model = model; engine.Power = power; engine.Displacement = displacement;
                engines.Add(engine);

            }
            else if (parameters.Length == 3)
            {
                string efficiency = parameters[2];
                Engine engine = new Engine();
                engine.Model = model; engine.Power = power; engine.Efficiency = efficiency;
                engines.Add(engine);
            }
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                engines.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
            }
            else
            {
                Engine engine = new Engine(); engine.Model = model; engine.Power = power;
                engines.Add(engine);
            }
        }
    }

}
