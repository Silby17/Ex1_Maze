using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {        
        public static int PORT;
        //IModel<T> model;

        static void Main(string[] args)
        {
            Console.WriteLine("Program Started");
            PORT = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);
            startServer(PORT);

            
        }

        public static void startServer(int port)
        {
            Console.WriteLine("Server Started");

            Console.WriteLine("Waiting for a connection......");
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, PORT);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);
            newsock.Listen(10);
            int clientNum = 0;
            while (true)
            {
                Socket client = newsock.Accept();
                Console.WriteLine("Client# {0} accepted!", ++clientNum);
                ClientHandler handler = new ClientHandler(client);          
                Thread t = new Thread(handler.handle);
                t.Start();
            }
        }
    }
}
