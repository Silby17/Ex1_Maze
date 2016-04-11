using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Ex1_Maze;
using System.Net.Sockets;

namespace Server2.Options
{
    public class Generate : ICommandable
    {
        public event ExecutionDone execDone;
        private string maze;
        private string JSONMaze;
        private GeneralMaze<int> gMa;
        private Socket clientToReturnTo;
        private string mazeName;


        /// <summary>
        /// Receives a list object from the Model.
        /// This method will convert the list to a string list
        /// and generate the maze with the correct Params</summary>
        /// <param Name="list">Object List of the Params</param>
        public void Execute(List<object> list, Socket client)
        {
            this.clientToReturnTo = client;
            List<string> strings = list.Select(s => (string)s).ToList();
            string name = strings[1];
            int type = Int32.Parse(strings[2]);
            this.mazeName = name;
            GenerateMaze(name, type);
            
        }


        /// <summary>
        /// Generate a new maze </summary>
        /// <param Name="name">Name of the the new maze</param>
        /// <param Name="type">The type of the new maze</param>
        public void GenerateMaze(string name, int type)
        {
            int height = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["HEIGHT"]);
            int width = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["WIDTH"]);
            _2DMaze<int> maze = new _2DMaze<int>(height, width);
            GeneralMaze<int> cMaze = new GeneralMaze<int>(maze);
            cMaze.Generate(name, type);
            maze.MakeMazeString();
            this.gMa = cMaze;
            //string jsonMaze = JsonConvert.SerializeObject(maze);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string jsonMaze = ser.Serialize(maze);
            jsonMaze = JToken.Parse(jsonMaze).ToString();
            
            File.WriteAllText(name+".json", jsonMaze);
            //this.JSONMaze = JToken.Parse(jsonMaze).ToString();
            this.JSONMaze = jsonMaze;
            PublishEvent();
        }

        /// <summary>
        /// This method will publish an event that the maze
        /// generation is completed</summary>
        public void PublishEvent()
        {
            if(execDone != null) { execDone(this, EventArgs.Empty); }
        }

        public string GetJSON()
        { return this.JSONMaze;}


        public GeneralMaze<int> GetGmaze() { return gMa; }


        /// <summary>
        /// Returns the Client socket that send the request</summary>
        /// <returns>Clients Socket Details</returns>
        public Socket GetClientSocket()
        { return this.clientToReturnTo; }

        public string GetMazeName()
        { return this.mazeName; }
    }

}