using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Option4 : ICommandable
    {
        public void execute()
        {
            Console.WriteLine("Option 4 was chosen");
        }
    }
}
