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
        GeneralMaze<T> GetMaze();
        Node<T> GetStartPoint();
        Node<T> GetEndPoint();
    }
}
