using System;
using System.Collections.Generic;

namespace _05PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Topping> toppings = new List<Topping>();

            string[] inputName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputDough = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = null;
            if (inputName.Length == 2)
            {
                name = inputName[1].ToLower();
            }

            string flourType = inputDough[1].ToLower();
            string bakingType = inputDough[2].ToLower();
            double weight = double.Parse(inputDough[3]);

            Dough dough = new Dough(flourType, bakingType, weight);
            double calories = dough.CalculateCallories();

            Pizza pizza = new Pizza(name, dough);
            string input = Console.ReadLine();
            
            while (input != "END")
            {
                string[] toppingInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                calories = CreateToppingAndCalculateCalories(toppings, calories, pizza, toppingInput);
                input = Console.ReadLine();
            }

            string capital = pizza.Name.Substring(0, 1).ToUpper();
            var capitalLetterName = capital + pizza.Name.ToString().Remove(0, 1);

            Console.WriteLine($"{capitalLetterName} - {calories:f2} Calories.");
        }

        private static double CreateToppingAndCalculateCalories(List<Topping> toppings, double calories, Pizza pizza, string[] toppingInput)
        {
            string toppingName = toppingInput[1].ToLower();
            double toppingWeight = double.Parse(toppingInput[2]);

            Topping topping = new Topping(toppingName, toppingWeight);
            calories += topping.CalculateCalories();
            toppings.Add(topping);
            pizza.AddToppings(topping);
            return calories;
        }
    }
}
