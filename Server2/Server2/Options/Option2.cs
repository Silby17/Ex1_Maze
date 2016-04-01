using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Generate : ICommandable
    {
        public void Execute(List<object> args)
        {
            Console.WriteLine("Option 2 was chosen");
        }
    }
}
