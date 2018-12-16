namespace LoggerLibrery.Abbenders
{
    using System.IO;

    using LoggerLibrery.Appenders;
    using LoggerLibrery.Appenders.Enums;
    using LoggerLibrery.Layouts.Contracts;
    using LoggerLibrery.Loggers;
   
    public class FileAppender : Appender
    {
        private const string path = "../../../log.txt";
        private readonly LogFile logfile;
        public FileAppender(ILayout layout) : base(layout)
        {
            this.logfile = new LogFile();
        }
        public FileAppender(ILayout layout, LogFile file) : this(layout)
        {
            this.logfile = new LogFile();
        }

        public override void Append(string dateAndTime, ReportLevel typeError, string message)
        {
            if (typeError >= this.ReportLevel)
            {
                this.MessagesCount++;
                string inputText = string.Format(this.Layout.Format, dateAndTime, typeError, message) + "\n";
                this.logfile.Write(inputText);
                File.AppendAllText(path, inputText);
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount} " +
                $"File size: {this.logfile.Sum}";
        }
    }
}
