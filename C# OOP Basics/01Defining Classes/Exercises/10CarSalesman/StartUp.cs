using System;
using System.Collections.Generic;

namespace _10CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] digits = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0};


            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            int countEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countEngines; i++)
            {
                string[] dataEngines = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                CreateEnginesAndAddThemToList(engines, dataEngines);

            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                CreateCarsAndAddThemToList(engines, cars, carData);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model + ":");
                Console.WriteLine($" {car.Engine.EngineModel}:\n  Power: {car.Engine.EnginePower}" +
                    $"\n  Displacement: {car.Engine.Displacement}\n  Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($" Weight: {car.CarWeight}\n Color: {car.CarColour}");
                
            }
        }

        private static void CreateCarsAndAddThemToList(List<Engine> engines, List<Car> cars, string[] carData)
        {
            string carModel = carData[0];
            Engine engineModel = engines.Find(x => x.EngineModel == carData[1]);
            Car currentCar = new Car(carModel, engineModel);

            if (carData.Length == 3)
            {
                if (int.TryParse(carData[2], out int result))
                {

                    currentCar.CarWeight = result.ToString();
                }
                else
                {
                    currentCar.CarColour = carData[2];
                }

            }
            else if (carData.Length == 4)
            {
                currentCar.CarWeight = carData[2];
                currentCar.CarColour = carData[3];
            }
            cars.Add(currentCar);
        }

        private static void CreateEnginesAndAddThemToList(List<Engine> engines, string[] dataEngines)
        {
            string engineModel = dataEngines[0];
            int enginePower = int.Parse(dataEngines[1]);
            string engineDisplacement = "n/a";
            string efficiencyEngine = "n/a";
            Engine currentEngine = new Engine(engineModel, enginePower);
            if (dataEngines.Length == 3)
            {
                if (int.TryParse(dataEngines[2], out int result))
                {
                    currentEngine.Displacement = dataEngines[2];
                }
                else
                {
                    currentEngine.Efficiency = dataEngines[2];
                }

            }
            else if (dataEngines.Length == 4)
            {
                engineDisplacement = dataEngines[2];
                efficiencyEngine = dataEngines[3];
                currentEngine.Displacement = engineDisplacement;
                currentEngine.Efficiency = efficiencyEngine;
            }
            engines.Add(currentEngine);
        }
    }
}
