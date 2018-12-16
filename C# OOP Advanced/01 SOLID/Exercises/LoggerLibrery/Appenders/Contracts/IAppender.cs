namespace LoggerLibrery.Appenders.Contracts
{
    using LoggerLibrery.Appenders.Enums;


    public interface IAppender
    {
        void Append(string dateAndTime, ReportLevel type, string message);

        ReportLevel ReportLevel { get; set; }

        int MessagesCount { get; }
    }
}
