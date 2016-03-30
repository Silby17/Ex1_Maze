using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class BestFS<T> : ISearcher<T>
    {
        private Maze maze;
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
                State<T> bestState = popOpenList();
                this.closedList.AddSolution(bestState);
                if (bestState.Equals(searchable.getIGoallState()))
                    return backTrace(); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State<T>> succerssors = searchable.getAllPossibleStates();
                foreach (State<T> s in succerssors)
                {
                    if (!this.closedList.Containe(s) && !this.openList.Containe(s))
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
        //returns the path
        private Solution<T> backTrace()
        {   //needs to go over all the states from goal to start and ask where did it "comefrom"
            throw new NotImplementedException();
        }

        //pop the best state (lowest move)
        private State<T> popOpenList()
        {
            State<T> ans = new State<T>();
            ans.SetCost(100000);
            foreach (State<T> s in this.openList.GetList())
            {
                if (s.GetCost() <= ans.GetCost())
                    ans = s;
            }
            throw new NotImplementedException();
        }
        //adds a state to the openList
        private void addToOpenList(State<T> state)
        {
            this.openList.GetList().Add(state);
            throw new NotImplementedException();
        
        }
        //adds a  List of states to the openList
        public void addToOpenList(List<State<T>> list)
        {   
            foreach(State<T> s in list)
            {
                this.addToOpenList(s);
            }
            throw new NotImplementedException();
        }

        State<T> ISearcher<T>.popOpenList()
        {
            throw new NotImplementedException();
        }
    }
}