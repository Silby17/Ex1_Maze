using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Ex1_Maze;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;


namespace Server2.Options
{
    public class Solve : ICommandable
    {
        public event ExecutionDone execDone;
        private Socket clientToReturnTo;
        private GeneralMaze<int> mazeToSolve;
        private string JSONSolvedMaze;


        /// <summary>
        /// Constructor method</summary>
        /// <param name="args">Arguments needed to solve the maze</param>
        /// <param name="client">Socket of the sender</param>
        /// <param name="list">List of Mazes</param>
        public void Execute(List<object> args, Socket client, Dictionary<string, GeneralMaze<int>> list)
        {
            this.clientToReturnTo = client;
            List<string> strParams = args.Select(s => (string)s).ToList();
            string mazeName = strParams[1];
            int type = Int32.Parse(strParams[2]);

            if (list.ContainsKey(mazeName))
            {
                this.mazeToSolve = list[mazeName];
            }
            SolveMaze(type);
            

        }

        public void SolveMaze(int type)
        {
            this.mazeToSolve.Solve(type);
            
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string jsonMaze = ser.Serialize(this.mazeToSolve);
            jsonMaze = JToken.Parse(jsonMaze).ToString();
            this.JSONSolvedMaze = jsonMaze;
            PublishEvent();
        }


        /// <summary>
        /// This will publish an event to all its listeners</summary>
        public void PublishEvent()
        {
            if(execDone != null){ execDone(this, EventArgs.Empty);}
        }
        /// <summary>
        /// Returns the Client socket that send the request</summary>
        /// <returns>Clients Socket Details</returns>
        public Socket GetClientSocket()
        { return this.clientToReturnTo; }


        public string GetJSON()
        { return this.JSONSolvedMaze; }

        public void Execute(List<object> args, Socket client)
        {}
    }
}
