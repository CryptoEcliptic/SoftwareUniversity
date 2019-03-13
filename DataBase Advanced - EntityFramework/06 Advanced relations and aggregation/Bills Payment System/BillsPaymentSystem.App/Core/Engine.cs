namespace BillsPaymentSystem.App.Core
{
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            bool IsEnd = false;
            while (!IsEnd)
            {
                string[] inputParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputParams[0] == "End")
                {
                    return;
                }
                
                using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
                {
                    try
                    {
                        string result = this.commandInterpreter.Read(inputParams, context);
                        Console.WriteLine(result);
                    }
                    catch (ArgumentNullException ane)
                    {
                        Console.WriteLine(ane.Message);
                    }
                   
                }
            }
        }
    }
}
