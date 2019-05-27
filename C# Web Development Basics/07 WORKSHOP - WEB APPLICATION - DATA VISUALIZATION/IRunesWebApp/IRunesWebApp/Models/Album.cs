namespace IRunesWebApp.Models
{
    using System;
    using System.Collections.Generic;

    public class Album : BaseModel<string>
    {
        public Album()
        {
            this.Tracks = new List<Track>();
        }

        public string Name  { get; set; }

        //url to cover photo
        public string Cover { get; set; }

        public decimal Price { get; set; }

        public DateTime AdditionDate { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
