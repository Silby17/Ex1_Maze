using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class Player
    {
        private Socket clientSocket;
        public GeneralMaze<int> maze;
        


        public Player(Socket client)
        {
            this.clientSocket = client;
        }

        public void SetPlayerMaze(GeneralMaze<int> m)
        {
            this.maze = m;
        }


        public Socket GetPlayerSocket()
        {
            return this.clientSocket;
        }
    }
}
