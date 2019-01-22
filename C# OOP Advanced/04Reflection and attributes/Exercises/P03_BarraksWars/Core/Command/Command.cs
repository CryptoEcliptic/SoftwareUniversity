using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.Command
{
    public abstract class Command : IExecutable
    {

        private string[] data;
        private IRepository repository;
        private IUnitFactory unitfactory;

        public Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected string[] Data
        {
            get { return data; }
            private set { data = value; }
        }

        protected IRepository Repository
        {
            get { return repository; }
            private set { repository = value; }
        }

        protected IUnitFactory UnitFactory
        {
            get { return unitfactory; }
            private set { unitfactory = value; }
        }

        public abstract string Execute();

    }
}
