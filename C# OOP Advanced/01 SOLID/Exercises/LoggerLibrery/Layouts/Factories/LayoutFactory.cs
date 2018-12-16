namespace LoggerLibrery.Layouts.Factories
{
    using System;

    using LoggerLibrery.Layouts.Contracts;
    using LoggerLibrery.Layouts.Factories.Contracts;
  
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "SimpleLayout":
                    return new SimpleLayout();

                case "XmlLayout":
                    return new XmlLayout();

                default:
                    throw new ArgumentException("Invalid layout type");
            }
        }
    }
}
