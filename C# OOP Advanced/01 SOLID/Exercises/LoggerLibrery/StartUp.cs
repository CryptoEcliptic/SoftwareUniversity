namespace LoggerLibrery
{
    using LoggerLibrery.Core;
    using LoggerLibrery.Core.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
