using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;


namespace Server2
{
    public class ClientHandler
    {
        private Socket client;
        private IPresenter chPresenter;
        private IView chView;


        public ClientHandler(Socket socket, IModel model)
        {
            this.client = socket;
            chView = new ClientView();
            chPresenter = new ClientPresenter(chView, model);
        }



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
                Console.WriteLine(str);
                handleRequest(str);
                
                //TO BE REMOVED IN ORDER TO KEEP SENDING REQUESTS TO SERVER
                data = Encoding.ASCII.GetBytes("Thanks");
                client.Send(data, data.Length, SocketFlags.None);
            }
            Console.ReadLine();
            client.Close();
        }


        public void handleRequest(string request)
        {
            
        }
    }
}

