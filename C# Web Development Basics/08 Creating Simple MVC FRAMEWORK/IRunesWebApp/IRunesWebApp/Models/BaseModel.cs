namespace IRunesWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BaseModel <TKey>
    {
        public TKey Id { get; set; }
    }
}
