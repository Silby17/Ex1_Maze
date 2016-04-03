using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class Solution<T>
    {
        private List<State<T>> list;

        public Solution(List<State<T>> list)
        {
            this.list = list;
        }

        public List<State<T>> GetList()
        {
            return this.list;
        }

        public void AddSolution(State<T> newSolution)
        {
            this.list.Add(newSolution);
        }

        public int GetLength()
        {
            return this.list.Count;
        }

        public int GetCost(State<T> givenState)
        {
            int ans = givenState.GetCost();
            foreach (State<T> s in this.list)
                {
                    if( s.GetCost() <= ans)
                    {
                        ans = s.GetCost();
                    }
                }
            return ans;
        }

        public bool Containe(State<T> s)
        {
            if (this.list.Contains(s))
                return true;
            else
                return false;
        }
    }
}