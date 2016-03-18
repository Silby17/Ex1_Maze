using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze.Model
{
    interface IMaze
    {
        void solveMaze(string mazeName);
        void getSolution();
    }
}
