namespace LoggerLibrery.Loggers
{
    using LoggerLibrery.Appenders.Contracts;
    using LoggerLibrery.Appenders.Enums;
    using LoggerLibrery.Loggers.Contracts;

    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;
        public ReportLevel ReportLevel { get; set; }
        internal int Size = 0;//ToDDO

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }
        public Logger(IAppender consoleAppender, IAppender fileAppender)
        {
            this.consoleAppender = consoleAppender;
            this.fileAppender = fileAppender;
        }


        public void Info(string dateTime, string message)
        {
            AppendMessages(dateTime, ReportLevel.INFO, message);
        }

        internal void Warning(string dateTime, string message)
        {
            AppendMessages(dateTime, ReportLevel.WARNING, message);
        }

        public void Error(string dateTime, string message)
        {
            AppendMessages(dateTime, ReportLevel.ERROR, message);
        }

        public void Critical(string dateTime, string message)
        {
            AppendMessages(dateTime, ReportLevel.CRITICAL, message);
        }

        public void Fatal(string dateTime, string message)
        {
            AppendMessages(dateTime, ReportLevel.FATAL, message);
        }

        private void AppendMessages(string dateTime, ReportLevel level, string message)
        {
            this.consoleAppender?.Append(dateTime, level, message);
            this.fileAppender?.Append(dateTime, level, message);
        }
    }
}
