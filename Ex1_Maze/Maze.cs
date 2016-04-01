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
            this.grid2D = new Node[5, 5];
            //this.grid2D = new Node[height, width];
            //Generation();
            Generate();
            print();
            this.height = height;
            this.width = width;
            this.type = type;
        }
        public void Generate()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    this.grid2D[i, j] = new Node(5);
                }
            }
        }

        public void print()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(grid2D[i, j].GetValue().ToString());
                }
                Console.WriteLine();
            }
        }



        public void Generation()
        {
            
            foreach (Node currentNode in this.grid2D)
            {
               
                //currentNode.SetValue(1);
            }
            PrintMaze(this.grid2D, 5, 5);
        }

        public static void PrintMaze(Node[,] maze, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(maze[i, j].GetValue());
                }
                Console.WriteLine();
            }
        }

        public void SetCell(int i,int j,int value)
        {
            Console.WriteLine("i = {0}  j ={1}", i ,j);
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
