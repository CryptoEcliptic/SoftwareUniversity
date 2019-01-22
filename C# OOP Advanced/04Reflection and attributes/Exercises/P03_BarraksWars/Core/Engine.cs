namespace _03BarracksFactory.Core
{
    using Contracts;
    using P03_BarraksWars;
    using System;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    CommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory);
                    var result = commandInterpreter.InterpretCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
