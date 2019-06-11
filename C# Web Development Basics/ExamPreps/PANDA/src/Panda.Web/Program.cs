using SIS.MvcFramework;
using System;

namespace Panda.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
