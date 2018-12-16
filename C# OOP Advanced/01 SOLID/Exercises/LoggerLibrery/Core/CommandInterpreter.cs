namespace LoggerLibrery.Core
{
    using System;
    using System.Collections.Generic;

    using LoggerLibrery.Appenders.Contracts;
    using LoggerLibrery.Appenders.Enums;
    using LoggerLibrery.Appenders.Factories;
    using LoggerLibrery.Appenders.Factories.Cotracts;
    using LoggerLibrery.Core.Contracts;
    using LoggerLibrery.Layouts.Contracts;
    using LoggerLibrery.Layouts.Factories;
    using LoggerLibrery.Layouts.Factories.Contracts;
   
    class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layOutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2], true);
            }
            ILayout layout = this.layoutFactory.CreateLayout(layOutType);
            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;
            this.appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0], true);
            string dateTime = args[1];
            string message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
