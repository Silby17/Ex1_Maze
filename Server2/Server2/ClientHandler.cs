using System;
using System.Net.Sockets;
using System.Text;

namespace Server2
{
    public class ClientHandler
    {
        private Socket client;
        private IPresenter chPresenter;
        private IView chView;


        /// <summary>
        /// Constructor method</summary>
        /// <param name="socket">The socket of client</param>
        /// <param name="model">The main Model</param>
        public ClientHandler(Socket socket, IModel model)
        {
            this.client = socket;
            chView = new ClientView();
            chPresenter = new ClientPresenter(chView, model);
        }


        /// <summary>
        /// The function that the server will use to handle
        /// the client</summary>
        public void handle()
        {
            Console.WriteLine("Starting Handler");
            byte[] data = new byte[1024];
            string wlc = "Welcome";
            data = Encoding.ASCII.GetBytes(wlc);
            client.Send(data, data.Length, SocketFlags.None);
            while (true)
            {
                data = new byte[1024];
                int recv = client.Receive(data);
                if (recv == 0) break;
                string str = Encoding.ASCII.GetString(data, 0, recv);
                if (str.Equals("exit")) break;
                Console.WriteLine(str);

                handleRequest(str);

                //TO BE REMOVED IN ORDER TO KEEP SENDING REQUESTS TO SERVER
                data = Encoding.ASCII.GetBytes("Thanks");
                client.Send(data, data.Length, SocketFlags.None);
            }
            Console.ReadLine();
            client.Close();
        }


        /// <summary>
        /// Handles the request from the client</summary>
        /// <param name="s">The command from the client</param>
        public void handleRequest(string s)
        {
            chView.NewInput(s);
        }
    }
}