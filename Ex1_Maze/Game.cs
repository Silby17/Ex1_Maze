using Ex1_Maze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class Game
    {

        public List<Player> playersList;
        public List<GeneralMaze<int>> mazeList;
        //private Dictionary<GeneralMaze<int>, Player> playersAndMazes;
        private string GameName;
        public Player player1{get; set;}
        public Player player2 { get; set; }
        private GeneralMaze<int> mazePlayer1;
        private GeneralMaze<int> mazePlayer2;

        public Game()
        { }


        public Game(GeneralMaze<int> m, string name)
        {
            this.mazePlayer1 = m;
            this.mazeList = new List<GeneralMaze<int>>();
            this.playersList = new List<Player>();
            this.GameName = name;
            this.mazeList.Add(m);
        }


        /// <summary>
        /// Creates a second maze for the Second player
        /// that has joined the game </summary>
        public void CreateSecondMaze()
        {
            Node<int>[,] grid = mazePlayer1.GetGrid();
            Node<int> start = mazePlayer1.GetStartPoint();
            Node<int> end = mazePlayer1.GetEndPoint();

            _2DMaze<int> twoDMaze = new _2DMaze<int>();
            twoDMaze.height = mazePlayer1.GetHeight();
            twoDMaze.width = mazePlayer1.GetWidth();
            twoDMaze.CopyGrid(grid);
            
            //Switches around the starting and ending cell in the Second Maze
            twoDMaze.SetStartingCell(end.GetRow(), end.GetCol());
            twoDMaze.SetEndingCell(start.GetRow(), start.GetCol());
            this.mazePlayer2 = new GeneralMaze<int>(twoDMaze);
            this.mazePlayer2.MakeMazeString();
            this.mazePlayer2.UpdateMembers();
            this.mazePlayer2.Name = this.mazePlayer1.Name + "_2";
        }


        public string GetGameName()
        {
            return this.GameName;
        }

        public void AddPlayers(Player p)
        {
            this.playersList.Add(p);
        }

        public void AssignPlayerToGame(Player player)
        {
            this.playersList.Add(player);
        }

        public List<Player> GetPlayersList()
        {
            return this.playersList;
        }

        public void AddPlayerAndMaze(GeneralMaze<int> maze, Player p)
        {
            //this.playersAndMazes.Add(maze, p);
        }



        public void SetMazePlayer2(GeneralMaze<int> maze)
        {
            this.mazePlayer2 = maze;
        }


        public GeneralMaze<int> GetPlayer1Maze()
        { return this.mazePlayer1; }

        public GeneralMaze<int> GetPlayer2Maze()
        { return this.mazePlayer2; }


        public void SetPlayers()
        {
            this.player1 = playersList[0];
            this.player2 = playersList[1];
        }
    }
}
