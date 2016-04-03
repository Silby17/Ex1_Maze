using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Generate : ICommandable
    {
        public void Execute(List<object> list)
        {
            Console.WriteLine("Option 1: Generate Maze");
            List<string> strings = list.Select(s => (string)s).ToList();
            string name = strings[1];
            int type = Int32.Parse(strings[2]);
            
        }
        

    }
}
