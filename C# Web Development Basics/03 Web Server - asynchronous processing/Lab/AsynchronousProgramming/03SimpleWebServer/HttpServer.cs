using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03SimpleWebServer
{
    public class HttpServer : IHttpServer
    {
        TcpListener tcpListener;
        private bool isStarted;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);
        }


        public void Start()
        {
            this.tcpListener.Start();
            isStarted = true;
            Console.WriteLine("Server started. Listening to TCP clients at 127.0.0.1:80");
            Console.WriteLine("Waiting for client...");

            while (isStarted)
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                Task.Run(() => ProcessClient(client));
            }
        }

        private static async void ProcessClient(TcpClient client)
        {
            var buffer = new byte[4096];
            var stream = client.GetStream();
            int readLength = await stream.ReadAsync(buffer, 0, buffer.Length);
            var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
            Console.WriteLine("Client connected");
            Console.WriteLine(requestText);

            await Task.Run(() => Thread.Sleep(10000));

            var responseText = DateTime.Now.ToString();
            var responseBytes = Encoding.UTF8.GetBytes(
                    "HTTP/1.0 200 OK" + Environment.NewLine +
                    "Content-Length: " + responseText.Length
                    + Environment.NewLine
                    + Environment.NewLine +
                        responseText);
            await stream.WriteAsync(responseBytes);
            Console.WriteLine("Closing connection.");
            Console.WriteLine("Waiting for client...");
            client.GetStream().Dispose();
        }

        public void Stop()
        {
            this.isStarted = false;
            this.tcpListener.Stop();
        }
    }
}
