
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using IO.Contracts;

	
	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;
        private IFestivalController festivalController;
        private ISetController setController;
        private bool isRunning;

        public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setController = setController;
            this.isRunning = true;
        }

		public void Run()
		{
			while (true)
			{
				var input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }
					
				try
				{
					
					string result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (ArgumentException ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			string end = this.festivalController.ProduceReport();
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			string[] args = input.Split();
			string command = args[0];
			string[] parameters = args.Skip(1).ToArray();


            string result;
			if (command == "LetsRock")
			{
				result = this.setController.PerformSets();
				return result;
			}
            else
            {
                try
                {
                    MethodInfo festivalControlFunction = this.festivalController.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

                    result = (string)festivalControlFunction.Invoke(this.festivalController, new object[] { parameters });

                    return result;
                }
                catch (TargetInvocationException ex)
                {

                    return $"ERROR: {ex.InnerException.Message}";
                }
                
            }
		}
	}
}