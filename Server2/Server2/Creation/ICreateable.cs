using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
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
