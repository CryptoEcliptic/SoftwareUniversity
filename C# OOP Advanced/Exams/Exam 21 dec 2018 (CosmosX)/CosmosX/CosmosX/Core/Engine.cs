using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System.Linq;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            isRunning = true;

            while (isRunning)
            {
                string[] inputCommands = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (inputCommands[0] == "Exit")
                {
                    isRunning = false;
                }

                try
                {
                    string result = this.commandParser.Parse(inputCommands);
                    writer.WriteLine(result);
                }
                catch(System.ArgumentNullException ane)
                {
                    writer.WriteLine(ane.Message);
                }
                catch (System.ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }



            }
            //It's not really necessary to implement this method

            //TODO After executed exit command should exit the whole system
        }
    }
}