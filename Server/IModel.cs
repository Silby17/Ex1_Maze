using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IModel<T>
    {
        Ex1_Maze.Maze Generate(string name, int type);
        Ex1_Maze.Solution<T> Solve(string name, int type);
        
    }
}
