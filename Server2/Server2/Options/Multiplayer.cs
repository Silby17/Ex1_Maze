using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Multiplayer : ICommandable
    {
        public event ExecutionDone execDone;
        private Socket clientToReturnTo;

        /// <summary>
        /// This method will start the execution of the Multiplayer
        /// game, and will recive the game name</summary>
        /// <param name="args">Will hold the game name</param>
        /// <returns></returns>
        public void Execute(List<object> args)
        {
            List<string> strParams = args.Select(s => (string)s).ToList();
            string gameName = strParams[1];
        }

        public string Execute(List<object> args, Socket client)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// This will publish an event to all its listeners</summary>
        public void PublishEvent()
        {
            if (execDone != null) {execDone(this, EventArgs.Empty);}
        }

        void ICommandable.Execute(List<object> args, Socket client)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the Client socket that send the request</summary>
        /// <returns>Clients Socket Details</returns>
        public Socket GetClientSocket()
        { return this.clientToReturnTo; }
    }
}
