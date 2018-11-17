namespace _10CarSalesman
{
    public class Engine
    {
        private string engineModel;
        private int enginePower;
        private string displacement;
        private string efficiency;

        public Engine(string engineModel, int enginePower)
        {
            this.EngineModel = engineModel;
            this.EnginePower = enginePower;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }
        

        public string EngineModel
        {
            get { return engineModel; }
            set { engineModel = value; }
        }

        public int EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }

        public string Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }




    }
}
