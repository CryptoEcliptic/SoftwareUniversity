﻿using PersonInfo.Core;
using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
