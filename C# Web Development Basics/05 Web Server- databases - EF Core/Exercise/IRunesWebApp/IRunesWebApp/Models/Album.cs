namespace IRunesWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Album : BaseModel<string>
    {
        //private const decimal discountPercentCoeff = 0.87m;

        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }

        public string Name  { get; set; }

        //url to cover photo
        public string Cover { get; set; }

        public decimal Price { get; set; } //TODO Calculate price discount

        public virtual IEnumerable<Track> Tracks { get; set; }
    }
}
