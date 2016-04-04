using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
   public class SearchableMaze<T> : ISearchable<T>
    {
        private Maze<T> maze;

       public SearchableMaze(Maze<T> maze)
        {
            this.maze = maze;
        }

        public List<Node<T>> getAllPossibleStates()
        {
            throw new NotImplementedException();
        }

        public List<Node<T>> getAllPossibleStates(Node<T> s)
        {
            throw new NotImplementedException();
        }

        public Node<T> getGoalState()
        {
            throw new NotImplementedException();
        }

        public object getIGoallState()
        {
            throw new NotImplementedException();
        }

        public Node<T> getInitialState()
        {
            throw new NotImplementedException();
        }

        public Maze<T> GetMaze()
        {
            throw new NotImplementedException();
        }
    }
    
}
