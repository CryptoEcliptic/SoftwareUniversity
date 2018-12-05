using _08MilitaryElite.Contracts;
using _08MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string codeName;

        private State state;

        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }

        public string CodeName
        {
            get { return codeName; }
            set { codeName = value; }
        }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }
        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
