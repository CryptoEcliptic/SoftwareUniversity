using _06BirthdayCelebrations.Contracts;

namespace _06BirthdayCelebrations.Models
{
    public class Robot : IRobot
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}
