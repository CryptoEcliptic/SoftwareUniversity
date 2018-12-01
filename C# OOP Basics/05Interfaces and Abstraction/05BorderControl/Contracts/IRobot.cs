using System;
using System.Collections.Generic;
using System.Text;

namespace _05BorderControl.Contracts
{
    public interface IRobot
    {
        string Model { get; }
        string Id { get; }
    }
}
