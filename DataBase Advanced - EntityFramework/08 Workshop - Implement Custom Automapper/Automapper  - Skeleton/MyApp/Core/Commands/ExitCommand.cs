using MyApp.Core.Commands.Contracts;
using System;

namespace MyApp.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return String.Empty;
        }
    }
}
