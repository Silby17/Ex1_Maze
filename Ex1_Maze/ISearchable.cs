using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public interface ISearchable
    {
        
        State<T> getInitialState();
        State<T> getGoalState();
        List<State> getAllPossibleStates(State s);
        
    }

}
