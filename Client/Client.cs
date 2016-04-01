using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class Client
    {
        private int PORT;
        private IPAddress IP;

        /// <summary>
        /// Starts the running of the Client/// </summary>
        public void StartClient()
        {
            Console.WriteLine("Client Started");
            PORT = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);
            IP = IPAddress.Parse(System.Configuration.ConfigurationManager.AppSettings["IP"]);

            IPEndPoint ipep = new IPEndPoint(IP, PORT);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ipep);
                Console.WriteLine("Connected to Server");
                byte[] data = new byte[1024];
                int recv = server.Receive(data);
                string stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);

                while (true)
                {
                    Console.WriteLine("Enter to send to Server:");
                    string input = Console.ReadLine();
                    if (input == "exit") break;
                    server.Send(Encoding.ASCII.GetBytes(input));
                    stringData = Encoding.ASCII.GetString(data, 0, recv);

                    recv = server.Receive(data);
                    stringData = Encoding.ASCII.GetString(data, 0, recv);
                    Console.WriteLine(stringData);
                }
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            catch (SocketException e) { Console.WriteLine("Unable to connect to server." + e.ToString()); }
        }
    }
}
