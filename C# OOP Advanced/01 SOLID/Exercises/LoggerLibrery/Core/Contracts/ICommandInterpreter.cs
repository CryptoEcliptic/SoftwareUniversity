namespace LoggerLibrery.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] aggs);

        void AddMessage(string[] args);

        void PrintInfo();
    }
}
