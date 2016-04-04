﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class BestFS<T> : ISearcher<T>
    {
        private Maze<T> maze;
        private Solution<T> closedList;
        private Solution<T> openList;
   
        public int getNumberOfNodesEvaluated()
        {
            return this.closedList.GetLength();
        }

        public Solution<T> Search(ISearchable<T> searchable)
        {
            this.closedList = new Solution<T>(new List<Node<T>>());
            this.openList = new Solution<T>(new List<Node<T>>());
            this.maze = searchable.GetMaze();
            // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState());
            // HashSet<State<T>> closed = new HashSet<State<T>>();
            while (getNumberOfNodesEvaluated() > 0)
            {
                // inherited from Searcher, removes the best state
                Node<T> bestState = popOpenList();
                this.closedList.AddSolution(bestState);
                if (bestState.Equals(searchable.getGoalState()))
                    return backTrace(searchable); // private method, back traces through the parents
                // calling the delegated method, returns a list of states with n as a parent
                List<Node<T>> succerssors = searchable.getAllPossibleStates(bestState);
                foreach (Node<T> s in succerssors)
                {
                    // If it is not in CLOSED and it is not in OPEN:
                    //evaluate it, add it to OPEN, and record its parent.
                    if (!this.closedList.Containe(s) && !this.openList.Containe(s))
                    {
                        s.SetCost(s.GetCost() + bestState.GetCost());
                        addToOpenList(s);
                        s.SetParent(bestState);
                    }

                    else
                    {
                        //Otherwise, if this new path is better than previous one, change its recorded parent.
                        if (s.GetCost() < this.closedList.GetCost(s))
                        {
                            s.SetParent(bestState);
                            //change the vlaue of s in closed list?
                        }
                        //i.  If it is not in OPEN add it to OPEN.
                        if (!this.openList.Containe(s))
                        {
                            addToOpenList(s);
                        }
                        // ii.Otherwise, adjust its priority in OPEN using this new evaluation.
                        else
                        {
                            this.openList.AddSolution(s);
                        }
                    }
                }
                //throw new NotImplementedException();
            }
           return(backTrace(searchable));
        }

        //returns the path, list of patrents.
        private Solution<T> backTrace(ISearchable<T> searchable)
        {
            Solution<T>  resultList = new Solution<T>(new List<Node<T>>());
            //needs to go over all the states from goal to start and ask where did it "comefrom"
            for (int i =this.closedList.GetLength() ;i != 0 ;i--)
            {
                resultList.AddSolution(this.closedList.GetList().ElementAt(i).GetParent());
                int row = this.closedList.GetList().ElementAt(i).GetRow();
                int col = this.closedList.GetList().ElementAt(i).GetCol();
                //changes value to 2 in maze and in closedlist
                searchable.GetMaze().SetCell(row, col, 2);
                this.closedList.GetList().ElementAt(i).SetValue(2);
            }
            return resultList;
        }

     

        //adds a state to the openList
        private void addToOpenList(Node<T> state)
        {
            this.openList.GetList().Add(state);
        }

        //adds a  List of states to the openList
        public void addToOpenList(List<Node<T>> list)
        {   
            foreach(Node<T> s in list)
            {
                this.addToOpenList(s);
            }   
        }

        //pop the best state (lowest move)
        public Node<T> popOpenList()
        {
            Node<T> ans = new Node<T>();
            ans.SetCost(100000);
            foreach (Node<T> s in this.openList.GetList())
            {
                if (s.GetCost() <= ans.GetCost())
                    ans = s;
            }
            return ans;
        }

       
    }
}