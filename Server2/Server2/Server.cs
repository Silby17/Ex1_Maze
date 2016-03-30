using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System;
using System.Net;


namespace Server2
{
    public class Server
    {
        private static int PORT;


        public void startServer()
        {            
            Console.WriteLine("Server Started");
            PORT = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);
            
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, PORT);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);
            newsock.Listen(10);
            int clientNum = 0;

            while (true)
            {
                Socket client = newsock.Accept();
                Console.WriteLine("Client# {0} accepted!", ++clientNum);
                ServerPresenter cPresenter = new ServerPresenter();
                ClientHandler handler = new ClientHandler(client, cPresenter);
                Thread t = new Thread(handler.handle);
                t.Start();
            }
        }
    }
}