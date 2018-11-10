using System;
using System.Collections;
using System.Collections.Generic;

namespace _01Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLigntTime = int.Parse(Console.ReadLine());
            int window = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            string inputCar = Console.ReadLine();
            bool hasCarAccident = false;
            int count = 0;

            while (inputCar != "END")
            {
                if (inputCar == "green")
                {
                    int currentGreen = greenLigntTime;
                    int currentWindow = window;
                    while (true)
                    {
                        if (cars.Count <= 0 || currentGreen <= 0)
                        {
                            break;
                        }
                        
                        string car = cars.Peek();
                        int greenAndWindow = currentGreen + currentWindow;

                        if (car.Length <= currentGreen)
                        {
                            cars.Dequeue();
                            count++;
                            currentGreen -= car.Length;
                        }

                        else if (currentGreen > 0 && car.Length > currentGreen)
                        {
                            currentGreen -= car.Length; 
                            greenAndWindow = currentWindow + currentGreen;
                            if (greenAndWindow >= 0)
                            {
                                cars.Dequeue();
                                count++;
                            }
                            else
                            {
                                int indexHit = Math.Abs(greenAndWindow);
                                char hitCar = car[car.Length - indexHit];

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {hitCar}.");
                                hasCarAccident = true;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(inputCar);
                }

                inputCar = Console.ReadLine();
            }

            if (hasCarAccident == false)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{count} total cars passed the crossroads.");
            }

        }
    }
}
