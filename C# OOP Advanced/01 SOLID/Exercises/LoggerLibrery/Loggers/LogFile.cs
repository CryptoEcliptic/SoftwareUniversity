namespace LoggerLibrery.Loggers
{
    using LoggerLibrery.Loggers.Contracts;
    using System.Linq;

    public class LogFile : ILogFile
    {
        public int Sum { get; private set; }

        public void Write(string message)
        {
            this.Sum += message.Where(char.IsLetter).Sum(x => x);
        }

    }
}
