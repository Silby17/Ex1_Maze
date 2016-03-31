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
        private int PORT;
        private IPresenter presenter;
        IModel model;

        /// <summary>
        /// The Server constructor</summary>
        public Server()
        {
            this.PORT = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);
            ServerView view = new ServerView();
            this.model = new ServerModel();
            this.presenter = new ServerPresenter(view, model);

        }

        public void startServer()
        {
            Console.WriteLine("Server Started");
            
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, PORT);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);
            newsock.Listen(10);
            int clientNum = 0;

            while (true)
            {
                Socket client = newsock.Accept();
                Console.WriteLine("Client# {0} accepted!", ++clientNum);
                ClientHandler handler = new ClientHandler(client, this.model);
                Thread t = new Thread(handler.handle);
                t.Start();
            }
        }
    }
}