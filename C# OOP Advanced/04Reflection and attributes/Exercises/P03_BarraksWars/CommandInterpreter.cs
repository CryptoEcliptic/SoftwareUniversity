using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Command;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace P03_BarraksWars
{
    public class CommandInterpreter
    {
        private const string CommandClassSuffix = "Command";
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public string InterpretCommand(string[] data, string commandName)
        {
            //Formating the input name in correspondence with class name
            string typeClassFullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandClassSuffix;

            Type classType = Type.GetType("P03_BarraksWars.Core.Command." + typeClassFullName); //Getting class type
            var commandClassInstance = (Command)Activator.CreateInstance(classType, new object[]
            { data, this.repository, this.unitFactory }); //Creating instance of the class. Providing the necessary params for the constructor

            MethodInfo currentMethod = classType.GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance);
            var result = currentMethod.Invoke(commandClassInstance, new object[] { }); //Creating result variable from type Object

            return result.ToString();
        }
    }
}
