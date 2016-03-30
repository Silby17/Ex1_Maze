using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Option3 : ICommandable
    {
        public void execute()
        {
            Console.WriteLine("Option 3 was chosen");
        }
    }
}
