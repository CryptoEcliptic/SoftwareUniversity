using SIS.MvcFramework;

namespace Torshia.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
