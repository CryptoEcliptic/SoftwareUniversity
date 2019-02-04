namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            string[] parameters = inputParameters.Skip(1).ToArray();

            string result = (string)this.tankManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command)
                .Invoke(this.tankManager, new object[] { parameters });

            return result;
        }
    }
}