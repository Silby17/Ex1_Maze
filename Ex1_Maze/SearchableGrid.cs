using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
   public class SearchableMaze<T> : ISearchable<T>
    {
        private Maze maze;

       public SearchableMaze(Maze maze)
        {
            this.maze = maze;
        }

        public List<State<T>> getAllPossibleStates()
        {
            throw new NotImplementedException();
        }

        public List<State<T>> getAllPossibleStates(State<T> s)
        {
            throw new NotImplementedException();
        }

        public State<T> getGoalState()
        {
            throw new NotImplementedException();
        }

        public object getIGoallState()
        {
            throw new NotImplementedException();
        }

        public State<T> getInitialState()
        {
            throw new NotImplementedException();
        }
    }
    
}
