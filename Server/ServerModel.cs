using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex1_Maze;

namespace Server
{
    class ServerModel<T> : IModel<T>
    {
        public Maze Generate(string name, int type)
        {
            throw new NotImplementedException();
        }

        public Solution<T> Solve(string name, int type)
        {
            throw new NotImplementedException();
        }
    }
}
