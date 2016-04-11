using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Close : ICommandable
    {
        public event ExecutionDone execDone;
        private Socket clientToReturnTo;


        /// <summary>
        /// Executes the Desired Functions
        /// </summary>
        /// <param name="args">List of params</param>
        public void Execute(List<object> args)
        {
            Console.WriteLine("Option 5 was chosen");
        }

        public void Execute(List<object> args, Socket client)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This will publish an event to all its listeners</summary>
        public void PublishEvent()
        {
            if (execDone != null)
            {
                execDone(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// Returns the Client socket that send the request</summary>
        /// <returns>Clients Socket Details</returns>
        public Socket GetClientSocket()
        { return this.clientToReturnTo; }

    }
}
