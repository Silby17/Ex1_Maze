using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class Model : IModel
    {
        private int PORT;
        private IPAddress IP;
        private Socket server;
        private IPEndPoint ipep;
        private Thread senderThread;
        private Thread receiverThread;
        private string fromServer;
        private string toSend;

        public event NewModelChange newModelChange;

        public Model()
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
        public void Start()
        {

            this.receiverThread = new Thread(ReceiveThread);
            receiverThread.Start();
        }


        /// <summary>
        /// Starts the Thread that will be in charge of incomming Data</summary>
        public void ReceiveThread()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[1024];
                    int recv = server.Receive(data);
                    string stringData = Encoding.ASCII.GetString(data, 0, recv);
                    if (stringData == "exit") break;
                    this.fromServer = stringData;
                    PublishEvent();
                    //Console.WriteLine(stringData);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Connection with Server has been Terminated: Server Shut Down.");
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                }
            }
        }

        public void Disconnect()
        {
            receiverThread.Abort();
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        /// <summary>
        /// This thread will be in charge of sending Data to the Server
        /// </summary>
        public void SendThread(string textToSend)
        {
            if (textToSend == "exit")
            {
                Disconnect();
            }
            else
                server.Send(Encoding.ASCII.GetBytes(textToSend));
        }





        public void PublishEvent()
        {
            if (this.newModelChange != null)
            {
                newModelChange(this, EventArgs.Empty);
            }
        }



        public string GetMessageFromServer()
        {
            if (this.fromServer != "")
            {
                string msg = this.fromServer;
                this.fromServer = "";
                return msg;
            }
            else
                return null;
        }
    }
}
