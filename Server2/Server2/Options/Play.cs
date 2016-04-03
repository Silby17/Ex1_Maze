using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Play : ICommandable
    {
        public void Execute(List<object> args)
        {
            Console.WriteLine("Option 4 was chosen");
        }
        public void Execute()
        {
            Console.WriteLine("Exectue without param");
        }
    }
}
