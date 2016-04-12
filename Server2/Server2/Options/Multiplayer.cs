using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Ex1_Maze;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Server2.Options
{
    public class Multiplayer : ICommandable
    {
        public event ExecutionDone execDone;
        private Socket clientToReturnTo;
        private List<Game> gamesList;
        private Dictionary<string, GeneralMaze<int>> mazeList;
        private int HIEGHT, WIDTH;
        private string JSONResult;
        private List<Game> gameList;

        /// <summary>
        /// Constructor Method that will get a list or arguments, the client that 
        /// send the request and the List of Mazes if needed</summary>
        /// <param name="args">List of arguments from client</param>
        /// <param name="client">Socket of the sender</param>
        /// <param name="mazeList">List of mazes</param>
        public void Execute(List<object> args, Socket client, Dictionary<string, GeneralMaze<int>> mazeList)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            this.mazeList = mazeList;
            SetSize();           
            
            //Creates a new Player
            Player player = new Player(client);
            //Gets the name of the Game
            string gameName = (string)args[1];
            //Converts the List of games from type object
            List<Game> games = (List<Game>)args[2];

            //If the Games List is not empty
            if(games.Count != 0)
            {
                foreach(Game g in games)
                {
                    if(g.GetGameName() == gameName)
                    {
                        //The Game already Exists in the list of games

                        //Adds new player to the game
                        g.AssignPlayerToGame(player);
                        g.CreateSecondMaze();

                    }

                }
            }
            //Create a new Game if the game doesnt Exist
            else
            {
                GeneralMaze<int> newMaze = CreateMultiMaze(gameName);
                this.mazeList.Add(newMaze.Name, newMaze);
                Game newGame = new Game(newMaze, gameName);
                newGame.AddPlayers(player);
                games.Add(newGame);
                string msg = "First Player To join";
                this.JSONResult = ser.Serialize(msg);
            }
        }


        /// <summary>
        /// This will publish an event to all its listeners</summary>
        public void PublishEvent()
        {
            if (execDone != null) {execDone(this, EventArgs.Empty);}
        }


        /// <summary>
        /// Returns the Client socket that send the request</summary>
        /// <returns>Clients Socket Details</returns>
        public Socket GetClientSocket()
        { return this.clientToReturnTo; }


        public GeneralMaze<int> CreateMultiMaze(string name)
        {
            _2DMaze<int> newMaze = new _2DMaze<int>(HIEGHT, WIDTH);
            GeneralMaze<int> newGM = new GeneralMaze<int>(newMaze);
            Random rand = new Random();
            int type = rand.Next(0, 2);
            string mazeName = name + "_1" + " " + type;
            newGM.Generate(mazeName, type);

            return newGM;
        }

        public string GetJSON()
        { return this.JSONResult; }

        public void SetSize()
        {
            this.HIEGHT = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["HEIGHT"]);
            this.WIDTH = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["WIDTH"]);
        }
    }
}
