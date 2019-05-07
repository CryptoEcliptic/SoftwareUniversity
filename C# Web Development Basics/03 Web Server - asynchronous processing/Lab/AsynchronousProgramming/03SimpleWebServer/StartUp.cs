using System;
using System.Threading;
using System.Threading.Tasks;

namespace _03SimpleWebServer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();
           
            var task = Task.Run(() => server.Start());
            task.Wait();


            server.Stop();
        }
    }
}
