using _05BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05BorderControl.Core
{
    public class Engine
    {
        public void Run()
        {
            List<string> allIDs = new List<string>();
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {

                if (input.Length == 2)
                {
                    string robotModel = input[0];
                    string robotId = input[1];

                    Robot robot = new Robot(robotModel, robotId);
                   
                    allIDs.Add(robot.Id);
                }
                else if (input.Length == 3)
                {
                    string humanName = input[0];
                    int age = int.Parse(input[1]);
                    string humanId = input[2];
                    Human human = new Human(humanName, age, humanId);
                   
                    allIDs.Add(human.Id);
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string fakeId = Console.ReadLine();

            
            allIDs = allIDs.FindAll(x => x.EndsWith(fakeId));
            foreach (var id in allIDs)
            {
                Console.WriteLine(id);
            }
            
        }
    }
}
