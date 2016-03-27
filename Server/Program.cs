using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Program
    {        
        public static int PORT;

        static void Main(string[] args)
        {
            Console.WriteLine("Server Started");
            Console.WriteLine("Waiting for a connection......");

            PORT = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any,PORT);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);
            newsock.Listen(10);

            while (true)
            {
                Socket client = newsock.Accept();
                ClientHandler handler = new ClientHandler(client);
                Thread t = new Thread(handler.handle);
                t.Start();
            }
        }
    }
}
