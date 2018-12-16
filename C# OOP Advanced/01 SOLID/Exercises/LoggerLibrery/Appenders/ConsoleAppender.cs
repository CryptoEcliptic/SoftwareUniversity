namespace LoggerLibrery.Appenders
{
    using System;

    using LoggerLibrery.Appenders.Contracts;
    using Layouts.Contracts;
    using LoggerLibrery.Appenders.Enums;

    public class ConsoleAppender : Appender
    {
        
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string dateAndTime, ReportLevel typeError, string message)
        {
            if (typeError >= this.ReportLevel)
            {
                this.MessagesCount++;
                Console.WriteLine(String.Format(this.Layout.Format, dateAndTime, typeError, message));
            }   
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}";
        }
    }
}
