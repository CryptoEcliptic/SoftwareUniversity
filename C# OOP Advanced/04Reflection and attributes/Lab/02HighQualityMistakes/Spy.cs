using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] fields = classType.GetFields(BindingFlags.Public |
            BindingFlags.Instance | BindingFlags.Static);

        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public |
            BindingFlags.Instance | BindingFlags.Static);

        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.NonPublic |
           BindingFlags.Instance | BindingFlags.Static);

        StringBuilder sb = new StringBuilder();

        foreach (var item in fields)
        {
            sb.AppendLine($"{item.Name} must be private!");
        }

        foreach (var item in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{item.Name} have to be public!");
        }

        foreach (var item in publicMethods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{item.Name} have to be private!");
        }

       
        return sb.ToString().TrimEnd();
    }
}

