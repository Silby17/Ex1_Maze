using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ClientHandler
    {
        private Socket client;

        public ClientHandler(Socket socket)
        {
            this.client = socket;
        }

        public void handle()
        {
            Console.WriteLine("Starting Handler");
            Console.WriteLine("Wating");
            
            byte[] data = new byte[1024];
            string wlc = "Welcome";
            data = Encoding.ASCII.GetBytes(wlc);
            client.Send(data, data.Length, SocketFlags.None);
            Console.WriteLine("I (Server) sent");
            Console.ReadLine();
            client.Close();
        }
    }
}

