using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex1_Maze
{
    public interface ISearchable<T>
    {
        Maze GetMaze();
        State<T> getInitialState();
        State<T> getGoalState();
        List<State<T>> getAllPossibleStates(State<T> s);
        object getIGoallState();
        List<State<T>> getAllPossibleStates();
    }

}
