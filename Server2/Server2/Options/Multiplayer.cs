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

        public void Execute(List<object> args)
        {
            Console.WriteLine("Option 3 was chosen");
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

    }
}
