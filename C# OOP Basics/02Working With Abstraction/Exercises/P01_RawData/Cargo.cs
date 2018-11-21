namespace P01_RawData
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(string type, int weight)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }



    }
}
