namespace LoggerLibrery.Appenders.Factories
{
    using System;

    using LoggerLibrery.Abbenders;
    using LoggerLibrery.Appenders.Contracts;
    using LoggerLibrery.Appenders.Factories.Cotracts;
    using LoggerLibrery.Layouts.Contracts;
   
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            switch (type)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout);
  
                case "FileAppender":
                    return new FileAppender(layout);

                default:
                    throw new ArgumentException("Invalid Appender type!");
            }
        }
    }
}
