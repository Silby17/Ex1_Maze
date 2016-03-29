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
                data = Encoding.ASCII.GetBytes("Thanks");
                client.Send(data, data.Length, SocketFlags.None);
            }
            Console.ReadLine();
            client.Close();
        }
    }
}

