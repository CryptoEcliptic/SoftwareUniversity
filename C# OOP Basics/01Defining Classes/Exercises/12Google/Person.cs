using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12Google
{
    public class Person
    {
        private string name;
        private Company company;
        private Car car;
        private List<Parent> parents;
        private List<Children> children;
        private List<Pokemon> pokemons;

        public Person(string name)
        {
            this.Name = name;
            this.parents = new List<Parent>();
            this.children = new List<Children>();
            this.pokemons = new List<Pokemon>();
            this.Car = car;
            this.Company = company;
        }
        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public List<Children> Children
        {
            get { return children; }
            set { children = value; }
        }

        public List<Parent> Parents
        {
            get { return parents; }
            private set { parents = value; }
        }

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);

            sb.AppendLine("Company:");
            if (this.Company != null)
            {
                sb.AppendLine(this.Company.ToString());
            }
            sb.AppendLine("Car:");
            if (this.Car != null)
            {
                sb.AppendLine(this.Car.ToString());
            }

            sb.AppendLine("Pokemon:");
            if (this.Pokemons.Count > 0)
            {
                sb.AppendLine(string.Join(Environment.NewLine, this.Pokemons.Select(x => x.ToString())));
            }

            sb.AppendLine("Parents:");
            if (this.parents.Count > 0)
            {
                sb.AppendLine(string.Join(Environment.NewLine, this.Parents.Select(x => x.ToString())));
            }

            sb.AppendLine("Children:");
            if (this.children.Count > 0)
            {
                sb.AppendLine(string.Join(Environment.NewLine, this.Children.Select(c => c.ToString())));
            }

            return sb.ToString();
        }
    }
}
