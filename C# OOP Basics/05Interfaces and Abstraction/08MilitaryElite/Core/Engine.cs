using _08MilitaryElite.Contracts;
using _08MilitaryElite.Enums;
using _08MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08MilitaryElite.Core
{
    public class Engine
    {
        private List<ISoldier> soldiers;
        private ISoldier soldier;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] argsInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = argsInput[0];
                string id = argsInput[1];
                string firstName = argsInput[2];
                string lastName = argsInput[3];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(argsInput[4]);
                    soldier = GerPrivateSoldier(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(argsInput[4]);
                    soldier = GetLieutenantGeneral(id, firstName, lastName, salary, argsInput);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(argsInput[4]);
                    soldier = GetEngineer(id, firstName, lastName, salary, argsInput);
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(argsInput[4]);
                    soldier = GetCommando(id, firstName, lastName, salary, argsInput);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(argsInput[4]);
                    soldier = GetSpy(id, firstName, lastName, codeNumber);
                }
                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
                
        }

        private ISoldier GetSpy(string id, string firstName, string lastName, int codeNumber)
        {
            ISpy spy = new Spy(id, firstName, lastName, codeNumber);
            return spy;
        }

        private ISoldier GetCommando(string id, string firstName, string lastName, decimal salary, string[] argsInput)
        {
            string corpsAsString = argsInput[5];
            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }

            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
            for (int i = 6; i < argsInput.Length; i+= 2 )
            {
                string codeName = argsInput[i];
                string stateAsString = argsInput[i + 1];
                if (!Enum.TryParse(stateAsString, out State state))
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);

                commando.Missions.Add(mission);

            }
            return commando;
        }

        private ISoldier GetEngineer(string id, string firstName, string lastName, decimal salary, string[] argsInput)
        {
            string corpsAsString = argsInput[5];
            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < argsInput.Length; i+=2)
            {
                string partName = argsInput[i];
                int workedHours = int.Parse(argsInput[i + 1]);

                IRepair repair = new Repair(partName, workedHours);
                engineer.Repairs.Add(repair);
            }

            return engineer;
        }

        private ISoldier GetLieutenantGeneral(string id, string firstName, string lastName, decimal salary, string[] argsInput)
        {
            ILieutenantGeneral lieutentGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < argsInput.Length; i++)
            {
                string privateId = argsInput[i];
                IPrivate privateSoldier = (IPrivate)this.soldiers.FirstOrDefault(x => x.Id == privateId);

                lieutentGeneral.Privates.Add(privateSoldier);
            }
            return lieutentGeneral;
        }

        private ISoldier GerPrivateSoldier(string id, string firstName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
            return privateSoldier;
        }
    }
}
