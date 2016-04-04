using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Solve : ICommandable
    {
        public event ExecutionDone execDone;



        /// <summary>
        /// This Method will Execute the Solving Algorithm</summary>
        /// <param name="args">The info of what maze and what Algorithm</param>
        /// <returns></returns>
        public string Execute(List<object> args)
        {
            List<string> strParams = args.Select(s => (string)s).ToList();
            string mazeName = strParams[1];
            int type = Int32.Parse(strParams[2]);

            return "DONE";
        }


        /// <summary>
        /// This will publish an event to all its listeners</summary>
        public void PublishEvent()
        {
            if(execDone != null){ execDone(this, EventArgs.Empty);}
        }

       
    }
}
