using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class BestFS<T> : ISearcher
    {
        private Node[,] maze;
        private Solution<T> closedList;
        private Solution<T> openList;

        public int getNumberOfNodesEvaluated()
        {
            return this.closedList.GetLength();
            throw new NotImplementedException();
        }

        public override Solution<T> Search(ISearchable<T> searchable)
        {
            this.closedList = new List<Solution<T>>;
            throw new NotImplementedException();
            // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState()); // inherited from Searcher
            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (OpenListSize > 0)
            {
                State<T> n = popOpenList();  // inherited from Searcher, removes the best state
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
        }

        Solution<T> ISearcher.Search(ISearchable searchable)
        {
            throw new NotImplementedException();
        }
    }
}