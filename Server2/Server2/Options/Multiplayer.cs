using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Ex1_Maze;

namespace Server2.Options
{
    public class Multiplayer : ICommandable
    {
        public event ExecutionDone execDone;
        private Socket clientToReturnTo;


        /// <summary>
        /// Constructor Method that</summary>
        /// <param name="args">Argumetns to be passed</param>
        /// <param name="client">THe socket of the sender</param>
        /// <param name="list">List of mazes if needed</param>
        public void Execute(List<object> args, Socket client, Dictionary<string, GeneralMaze<int>> list)
        {
            List<string> strParams = args.Select(s => (string)s).ToList();
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

    }
}
