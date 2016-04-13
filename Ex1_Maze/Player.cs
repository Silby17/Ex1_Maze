
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Linq;
using System.IO;
using Ex1_Maze;
using System;

namespace Ex1_Maze
{
    public class Player
    {
        public string Name { get; set;}
        public string MazeName { get; set; }
        public string You { get; set; }
        public string Other { get; set; }

        private Socket clientSocket;
        private GeneralMaze<int> playerMaze;
        private string JSONString;
        


        public Player(Socket client)
        {
            this.clientSocket = client;
        }

        public void SetPlayerMaze(GeneralMaze<int> m)
        {
            this.playerMaze = m;
        }


        public Socket GetPlayerSocket()
        {
            return this.clientSocket;
        }

        public void SetJSON(string str)
        {
            this.JSONString = str;
        }
        

        public string GetJSON()
        {
            
            return this.JSONString;
        }

        public GeneralMaze<int> GetPlayerMaze()
        {
            return this.playerMaze;
        }
    }
}
