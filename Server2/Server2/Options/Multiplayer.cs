using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Multiplayer : ICommandable
    {
        public event ExecutionDone execDone;


        /// <summary>
        /// This method will start the execution of the Multiplayer
        /// game, and will recive the game name</summary>
        /// <param name="args">Will hold the game name</param>
        /// <returns></returns>
        public string Execute(List<object> args)
        {
            List<string> strParams = args.Select(s => (string)s).ToList();
            string gameName = strParams[1];
            return "Multi";
        }


        /// <summary>
        /// This will publish an event to all its listeners</summary>
        public void PublishEvent()
        {
            if (execDone != null) {execDone(this, EventArgs.Empty);}
        }

        
    }
}
