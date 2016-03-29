using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class BestFS<T> : ISearcher<T>
    {
        private Node[,] maze;
        private Solution<T> closedList;
        private Solution<T> openList;

        public int getNumberOfNodesEvaluated()
        {
            return this.closedList.GetLength();
            throw new NotImplementedException();
        }

        public Solution<T> Search(ISearchable<T> searchable)
        {
            this.closedList = new Solution<T>(new List<State<T>>());
            this.openList = new Solution<T>(new List<State<T>>());

            // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState()); 
          //  HashSet<State<T>> closed = new HashSet<State<T>>();
            while (getNumberOfNodesEvaluated() > 0)
            {
                // inherited from Searcher, removes the best state
                State<T> n = popOpenList();  
                closed.Add(n);
                if (n.Equals(searchable.getIGoallState()))
                    return backTrace(); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s) && !openContaines(s))
                    {
                        // s.setCameFrom(n);  // already done by getSuccessors
                        addToOpenList(s);
                    }
                    else
                    {
                        //...

                    }
                }
            }
            throw new NotImplementedException();
        }

        private void addToOpenList(State<T> state)
        {
            this.openList.Add(state);
            throw new NotImplementedException();
        
        }

        public void addToOpenList(List<State<T>> list)
        {
            throw new NotImplementedException();
        }
    }
}