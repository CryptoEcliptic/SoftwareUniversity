namespace LoggerLibrery.Layouts.Factories.Contracts
{
    using LoggerLibrery.Layouts.Contracts;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
