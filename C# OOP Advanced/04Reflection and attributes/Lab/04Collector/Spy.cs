using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        Type typeClass = Type.GetType(className);

        MethodInfo[] methods = typeClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Public
            | BindingFlags.Instance | BindingFlags.Static);

        StringBuilder output = new StringBuilder();

        foreach (var method in methods.Where(x => x.Name.StartsWith("get")))
        {
            output.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
        {
            output.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return output.ToString().TrimEnd();
    }
}

