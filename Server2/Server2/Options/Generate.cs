using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Server2.Options
{




    public class Generate : ICommandable
    {
        public event ExecutionDone execDone;
        private string maze;

        /// <summary>
        /// Receives a list object from the Model.
        /// This method will convert the list to a string list
        /// and generate the maze with the correct Params</summary>
        /// <param Name="list">Object List of the Params</param>
        public void Execute(List<object> list)
        {
            List<string> strings = list.Select(s => (string)s).ToList();
            string name = strings[1];
            int type = Int32.Parse(strings[2]);
            string JSONMaze = GenerateMaze(name, type);
        }


        /// <summary>
        /// Generate a new maze </summary>
        /// <param Name="name">Name of the the new maze</param>
        /// <param Name="type">The type of the new maze</param>
        public string GenerateMaze(string name, int type)
        {
            int height = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["HEIGHT"]);
            int width = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["WIDTH"]);
            string jsonMaze;
            Maze maze = new Maze(height, width);
            CreateableMaze<int> Cm = new CreateableMaze<int>(maze);
            Cm.Generate(name, type);
            //maze.Print();

            jsonMaze = JsonConvert.SerializeObject(maze);
            jsonMaze = JToken.Parse(jsonMaze).ToString();
            File.WriteAllText(name+".json", jsonMaze);
            PublishEvent();
            return jsonMaze;            
        }

        /// <summary>
        /// This method will publish an event that the maze
        /// generation is completed</summary>
        public void PublishEvent()
        {
            if(execDone != null)
            {
                execDone(this, EventArgs.Empty);
            }
        }
    }
}