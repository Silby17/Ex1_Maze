using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Started");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int PORT = 80;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORT);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ipep);
                Console.WriteLine("Here 1");
                byte[] data = new byte[1024];
                int recv = server.Receive(data);
                string stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);

                while (true)
                {
                    Console.WriteLine("Here 2 ");
                    Console.WriteLine("enter");
                    string input = Console.ReadLine();
                    if (input == "exit") break;
                    server.Send(Encoding.ASCII.GetBytes(input));
                   // byte[] data = new byte[1024];
                    //int recv = server.Receive(data);
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