namespace _12Google
{
    public class Children
    {
        private string name;
        private string birthday;

        public Children(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}
