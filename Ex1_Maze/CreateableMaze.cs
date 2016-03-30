using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public  class CreateableMaze<T> : ICreateable<T>
    {
        private Maze maze;
       
        public CreateableMaze(Maze maze)
        {
            this.maze = maze;  
        }
        public int GetHeight()
        {
            return this.maze.GetHeight();
        }

        public Maze GetMaze()
        {
            return this.maze;
        }

        //returns the grid itself
        public Node[,] GetGrid()
        {
            return this.maze.GetMaze();
        }

        public int GetWidth()
        {
            return this.maze.GetWidth();
        }

        int ICreateable<T>.GetType()
        {
            return this.maze.GetType();

        }
    }
}
