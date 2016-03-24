using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    class SearchableGrid : ISearchable
    {
        private Maze currentGrid;

        public List<State> getAllPossibleStates(State s)
        {
            throw new NotImplementedException();
        }
        
        public State<T> getGoalState()
        {
            throw new NotImplementedException();
        }

        public State<T> getInitialState()
        {
            throw new NotImplementedException();
        }
    }
}