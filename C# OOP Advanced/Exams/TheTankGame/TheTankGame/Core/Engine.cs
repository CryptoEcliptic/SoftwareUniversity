namespace TheTankGame.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }
        
        public void Run()
        {
            while (this.isRunning)
            {
                string input = reader.ReadLine().TrimEnd();
                if (input == "Terminate")
                {
                    this.isRunning = false;
                }
                string[] args = input.Split();

                try
                {
                    string result = this.commandInterpreter.ProcessInput(args);
                    writer.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }
        }
    }
}