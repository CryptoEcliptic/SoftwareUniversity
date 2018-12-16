namespace LoggerLibrery.Appenders
{
    using LoggerLibrery.Appenders.Contracts;
    using LoggerLibrery.Appenders.Enums;
    using LoggerLibrery.Layouts.Contracts;

    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }
        protected ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateAndTime, ReportLevel type, string message);
    }
}
