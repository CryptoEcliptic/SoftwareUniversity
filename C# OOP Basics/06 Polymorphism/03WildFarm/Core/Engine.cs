using _03WildFarm.AnimalModels;
using _03WildFarm.Factories;
using System;
using System.Collections.Generic;

namespace _03WildFarm.Core
{
    public class Engine
    {
        private FoodFactory foodFactory;
        private BirdFactory birdFactory;
        private MammalFactory mammalFactory;
        private FelineFactory felineFactory;
        private List<Animal> animals;
        private Animal animal;
        public Engine()
        {
            this.foodFactory = new FoodFactory();
            this.birdFactory = new BirdFactory();
            this.mammalFactory = new MammalFactory();
            this.felineFactory = new FelineFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] animalArguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeAnimal = animalArguments[0].ToLower();
                string name = animalArguments[1];
                double weight = double.Parse(animalArguments[2]);

                if (typeAnimal == "hen" || typeAnimal == "owl")
                {
                    double wingSize = double.Parse(animalArguments[3]);
                    animal = birdFactory.CreateBird(typeAnimal, name, weight, wingSize);
                }
                else if (typeAnimal == "mouse" || typeAnimal == "dog")
                {
                    string livingRegion = animalArguments[3];
                    animal = mammalFactory.CreateMammal(typeAnimal, name, weight, livingRegion);
                }
                else if (typeAnimal == "cat" || typeAnimal == "tiger")
                {
                    string livingRegion = animalArguments[3];
                    string breed = animalArguments[4];
                    animal = felineFactory.CreateFeline(typeAnimal, name, weight, livingRegion, breed);
                }

                animal.ProduceSound();
                string[] foodArguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeFood = foodArguments[0];
                int quantity = int.Parse(foodArguments[1]);
                var food = foodFactory.CreateFood(typeFood, quantity);
                
                animal.Eat(food);
                this.animals.Add(animal);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
           

        }
    }
}
