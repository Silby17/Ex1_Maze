using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    //This is a base form of a grid maze.
    public class Maze
    {
        private Node[,] grid2D;
        public int height;
        public int width;
        public int type;

        public Maze(int height, int width, int type)
        {
            this.grid2D = new Node[height, width];
            this.height = height;
            this.width = width;
            this.type = type;
        }
        public void SetCell(int i,int j,int value)
        {
            this.grid2D[i, j].SetValue(value);
        }

        public int GetValue(int i, int j)
        {
           return this.grid2D[i, j].GetValue();
        }

        public Node[,] GetMaze()
        {
            return this.grid2D;
        }

        public int GetHeight()
        {
            return this.height;
        }

        public int GetWidth()
        {
            return this.width;
        }

        public int GetType()
        {
            return this.type;
        }

    }
}
