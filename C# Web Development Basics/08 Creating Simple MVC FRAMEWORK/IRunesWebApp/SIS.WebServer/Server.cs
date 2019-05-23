namespace SIS.WebServer
{
    using SIS.WebServer.Api;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class Server
    {
        private const string LocalHostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private readonly IHttpHandler handler;

        private bool isRunning;

        public Server(int port, IHttpHandler handler)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIpAddress), this.port);
            this.handler = handler;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalHostIpAddress}:{this.port}");

            try
            {
                var task = Task.Run(this.ListenLoopAsync);
                task.Wait();
            }
            catch (System.AggregateException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        public async Task ListenLoopAsync()
        {
            while (this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.handler);
                var responseTask = connectionHandler.ProcessRequestAsync();
                responseTask.Wait();
            }
        }
    }
}
