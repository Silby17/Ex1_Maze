using System.Threading.Tasks;
using System.Net.Sockets;
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
            //Reads the port from the ConfigFile
            this.PORT = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);
            ServerView view = new ServerView();
            
            //Creates new Model
            this.model = new Model();

            //Creates new Presenter
            this.presenter = new ServerPresenter(view, model);
        }


        /// <summary>
        /// This method starts the running of the Server</summary>
        public void StartServer()
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
                //Console.WriteLine("Client# {0} accepted!", ++clientNum);
                ClientHandler handler = new ClientHandler(client, this.model);
                Task.Factory.StartNew(handler.handle);
            }
        }
    }
}