using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public interface ICreateable<T>
    {
        int GetHeight();
        int GetWidth(); 
        Maze GetMaze();
        Node GetStartPoint();
        Node GetEndPoint();
    }
}
