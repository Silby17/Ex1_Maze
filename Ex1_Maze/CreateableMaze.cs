using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public  class CreateableMaze<T> : ICreateable<T>//,ISearchable<T>
    {
        private Maze maze;
       
        public CreateableMaze(Maze maze)
        {
            this.maze = maze;  
        }

        public void Generate(string name, int type)
        {
            this.maze.Generate(name, type);
            //DFS
            if (1 == type)
            {
                Dfs<int> D = new Dfs<int>();
                D.create(new CreateableMaze<int>(maze));
            }
            //Random
            if (0 == type)
            {
                RandomCreation<int> R = new RandomCreation<int>();
                R.create(new CreateableMaze<int>(maze));
            }
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

  
        public Node GetStartPoint()
        {
           return(new Node(0, 0,new Random().Next(0, GetHeight()-1)));
        }

        public Node GetEndPoint()
        {
            return(new Node(0, new Random().Next(0, GetWidth() - 1), GetHeight()-1));
           
        }
    }
}
