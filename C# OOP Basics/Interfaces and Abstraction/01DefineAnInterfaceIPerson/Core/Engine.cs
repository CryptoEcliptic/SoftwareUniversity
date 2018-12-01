﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Core
{
    public class Engine
    {
        public void Run()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);

        }
    }
}
