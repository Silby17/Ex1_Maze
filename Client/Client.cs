using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public class Client
    {
        private int PORT;
        private IPAddress IP;
        private Socket server;
        private IPEndPoint ipep;

        /// <summary>
        /// Constructor Method of the Client</summary>
        public Client()
        {
            //Reads the PORT and IP number from the Configuration file
            PORT = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);
            IP = IPAddress.Parse(System.Configuration.ConfigurationManager.AppSettings["IP"]);

            this.ipep = new IPEndPoint(IP, PORT);
            this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            //Try to connect to the Server
            try
            {
                server.Connect(ipep);
                Console.WriteLine("Connected To Server");
            }
            catch (SocketException e) { Console.WriteLine("Unable to connect to server." + e.ToString()); }
        }


        /// <summary>
        /// Starts the running of the Client/// </summary>
        public void StartClient()
        {
            Thread sender = new Thread(SendThread);
            Thread rece = new Thread(ReceiveThread);
            sender.Start();
            rece.Start();            
        }


        /// <summary>
        /// Starts the Thread that will be in charge of incomming Data</summary>
        public void ReceiveThread()
        {
            while(true)
            {
                byte[] data = new byte[1024];
                int recv = server.Receive(data);
                string stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);
            }
        }


        /// <summary>
        /// This thread will be in charge of sending Data to the Server
        /// </summary>
        public void SendThread()
        {
            while (true)
            {
                string toSend = Console.ReadLine();
                if (toSend == "exit") break;
                server.Send(Encoding.ASCII.GetBytes(toSend));
            }
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}