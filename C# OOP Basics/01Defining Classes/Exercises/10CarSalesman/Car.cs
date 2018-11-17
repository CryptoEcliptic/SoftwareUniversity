namespace _10CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private string carWeight;
        private string carColour;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.CarWeight = "n/a";
            this.CarColour = "n/a";
        }
       

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string CarWeight
        {
            get { return carWeight; }
            set { carWeight = value; }
        }

        public string CarColour
        {
            get { return carColour; }
            set { carColour = value; }
        }
    }
}
