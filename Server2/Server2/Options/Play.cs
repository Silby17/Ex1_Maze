using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Play : ICommandable
    {
        public event ExecutionDone execDone;


        /// <summary>
        /// This method will execute the players move</summary>
        /// <param name="args"></param>
        public string Execute(List<object> args)
        {
            List<string> strParams = args.Select(s => (string)s).ToList();
            string move = strParams[1];

            return move;
        }


        /// <summary>
        /// This will publish an event to all its listeners</summary>
        public void PublishEvent()
        {
            if (execDone != null) {execDone(this, EventArgs.Empty);}
        }

    }
}
