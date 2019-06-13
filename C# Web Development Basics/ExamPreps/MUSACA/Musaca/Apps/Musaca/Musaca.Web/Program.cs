using SIS.MvcFramework;
using System;

namespace Musaca.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
