using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex1_Maze
{
    public interface ISearchable<T>
    {
        Maze<T> GetMaze();
        Node<T> getInitialState();
        Node<T> getGoalState();
        List<Node<T>> getAllPossibleStates(Node<T> n);
        
    }

}
