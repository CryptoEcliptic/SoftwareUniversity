using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Repository;
using System;

namespace _07InfernoInfinity.Core
{
    public class Engine
    {
        private IWeaponRepository repository;
        private CommandInterpreter commandInterpreter;
        public Engine()
        {
            this.repository = new WeaponRepository();
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] args = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];
                switch (command)
                {
                    case "Create":
                        IWeapon weapon = commandInterpreter.CreateCommand(args);
                        repository.AddWeapon(weapon);
                        break;

                    case "Add":
                        IGem gem = commandInterpreter.CreateGem(args);
                        string weaponName = args[1];
                        int socketIndex = int.Parse(args[2]);
                        this.repository.AddGem(weaponName, socketIndex, gem);
                        break;

                    case "Remove":
                        string targetName = args[1];
                        int removeIndex = int.Parse(args[2]);
                        this.repository.RemoveGem(targetName, removeIndex);
                        break;

                    case "Print":
                        string name = args[1];
                        string result = repository.Print(name);
                        Console.WriteLine(result);
                        break;
                }
                    
                input = Console.ReadLine();
            }
        }
    }
}
