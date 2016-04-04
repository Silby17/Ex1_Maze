using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Server2
{
    
    public class ServerView : IView
    {
        public event NewViewChangeEvent newInput;
        private Socket client;
        private string stringToSend {get; set;}
        private int ID;


        public ServerView(Socket socket, int id)
        {
            this.client = socket;
            this.ID = id;
        }


        public void handle()
        {
            byte[] data = new byte[1024];
            string wlc = "Welcome";
            data = Encoding.ASCII.GetBytes(wlc);
            //Server sends welcome msg to Client
            client.Send(data, data.Length, SocketFlags.None);
            Thread recThread = new Thread(ReceiveThread);
            recThread.Start();
        }



        /// <summary>
        /// This method with be run by a thread and will be in charge
        /// of receiving data</summary>
        public void ReceiveThread()
        {
            byte[] data = new byte[1024];
            while (true)
            {
                data = new byte[1024];
                int recv = client.Receive(data);
                if (recv == 0) break;
                string str = Encoding.ASCII.GetString(data, 0, recv);
                if (str.Equals("exit")) break;
                OnNewInput(str);
            }
            client.Close();
        }


        /// <summary>
        /// This method will be run on a seperate thread
        /// and it will be in charge of sending data to the Client</summary>
        /// <param name="str">The string to send to Client</param>
        public void Send(string str)
        {
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(str);
            //Server sends welcome msg to Client
            client.Send(data, data.Length, SocketFlags.None);
        }



        public void DisplayData(string data)
        {
            Send(data);
        }

        public void OnNewInput(string str)
        {
            this.stringToSend = str;
            PublishEvent();
        }


        public void PublishEvent()
        { if (newInput != null) newInput(this, EventArgs.Empty); }



        public string GetStringInput()
        {
            return this.stringToSend;
        }
    }
    
}
