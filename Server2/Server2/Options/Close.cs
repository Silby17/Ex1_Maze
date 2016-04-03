using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Close : ICommandable
    {
        public event ExecutionDone execDone;


        /// <summary>
        /// Executes the Desired Functions
        /// </summary>
        /// <param name="args">List of params</param>
        public void Execute(List<object> args)
        {
            Console.WriteLine("Option 5 was chosen");
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
