using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public interface ICreateable
    {
        int GetType();
        int GetHeight();
        int GetWidth();
        Node[,] GetMaze();
    }
}
