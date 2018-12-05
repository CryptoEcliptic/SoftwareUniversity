using _07FoodShortage.Contracts;

namespace _07FoodShortage.Models
{
    public class Pet : IPet
    {
        private string name;

        private string birthdate;

        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.Birthdate = birthDate;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }


    }
}
