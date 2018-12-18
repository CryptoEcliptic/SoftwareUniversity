using System;
using System.Collections.Generic;
using System.Text;


public abstract class Item
{
    public Item(string id)
    {
        this.Id = id;
    }
    public string Id { get; protected set; }
}

