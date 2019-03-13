namespace BillsPaymentSystem.App
{
    using BillsPaymentSystem.App.Core;
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommangInterpreter();

            IEngine engine = new Engine(commandInterpreter);
            engine.Run();

            //var context = new BillsPaymentSystemContext();
            //using (context)
            //{
            //    DbInitializer.Seed(context);
            //}
        }
    }
}
