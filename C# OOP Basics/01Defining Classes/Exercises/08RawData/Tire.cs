namespace _08RawData
{
    public class Tire
    {
        private int tireAge;
        private double tirePressure;

        public Tire(int age, double pressure)
        {
            TireAge = age;
            TirePressure = pressure;
        }
        public int TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }

        public double TirePressure
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }


    }
}
