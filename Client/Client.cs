using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Net;
using System;


namespace Client
{
    public class Client
    {
        private int PORT;
        private IPAddress IP;
        private Socket server;
        private IPEndPoint ipep;
        private Thread senderThread;
        private Thread receiverThread;

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
            this.senderThread = new Thread(SendThread);
            this.receiverThread = new Thread(ReceiveThread);
            senderThread.Start();
            receiverThread.Start();            
        }


        /// <summary>
        /// Starts the Thread that will be in charge of incomming Data</summary>
        public void ReceiveThread()
        {
            while(true)
            {
                try
                {
                    byte[] data = new byte[1024];
                    int recv = server.Receive(data);
                    string stringData = Encoding.ASCII.GetString(data, 0, recv);
                    Console.WriteLine(stringData);
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Connection with Server has been Terminated: Server Shut Down.");
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                }
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
            receiverThread.Abort();
            Console.WriteLine("Broken here in client");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}