namespace LoggerLibrery.Appenders.Factories.Cotracts
{
    using LoggerLibrery.Appenders.Contracts;
    using LoggerLibrery.Layouts.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
