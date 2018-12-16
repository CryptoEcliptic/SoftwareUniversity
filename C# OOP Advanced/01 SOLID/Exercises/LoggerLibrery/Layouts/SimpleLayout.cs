namespace LoggerLibrery.Layouts
{
    using System;

    using LoggerLibrery.Layouts.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
