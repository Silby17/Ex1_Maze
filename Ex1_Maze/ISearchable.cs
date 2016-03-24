using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public interface ISearchable
    {
        State<T> getInitialState();
        State<T> getGoalState();
        List<State> getAllPossibleStates(State s);
    }

}
