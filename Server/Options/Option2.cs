using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Options
{
    public class Option2 : ICommandable
    {
        public void Execute()
        {
            Console.WriteLine("Option 2 was chosen");
        }
    }
}
