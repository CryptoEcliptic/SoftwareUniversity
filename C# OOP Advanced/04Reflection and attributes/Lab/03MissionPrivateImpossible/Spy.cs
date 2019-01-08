using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        Type type = Type.GetType(className);

        
        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);


        StringBuilder output = new StringBuilder();
        output.AppendLine($"All Private Methods of Class: {className}");
        output.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            output.AppendLine(method.Name);
        }

        return output.ToString().TrimEnd();
    }
}
