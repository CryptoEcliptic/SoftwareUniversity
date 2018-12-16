namespace LoggerLibrery.Loggers.Contracts
{
    public interface ILogFile
    {
        void Write(string message);

        int Sum { get; }
    }
}
