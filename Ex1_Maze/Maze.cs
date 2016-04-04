using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    //This is a base form of a grid maze.
    public class Maze<T>
    {
        private Node<T>[,] grid2D;
        private int height;
        private int width;
  

        public Maze(int height, int width)
        {
            this.height = height;
            this.width = width;
            this.grid2D = new Node<T>[height, width];
        }
        
        public void Generate(string name, int type)
        {
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    this.grid2D[i, j] = new Node<T>(1,i,j);
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

        public Node<T> GetNode(int i, int j)
        {

            return (this.grid2D[i, j]);
        }

        public static void PrintMaze(Node<T>[,] maze, int row, int column)
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
           // Console.WriteLine("i = {0}  j ={1}", i ,j);
            this.grid2D[i, j].SetValue(value);
        }

        public int GetValue(int i, int j)
        {
           return (this.grid2D[i, j].GetValue());
        }

        public Node<T>[,] GetMaze()
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
        //returns the index i of a cell
        public int GetIndexRow(int val)
        {
            int ans = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if(this.grid2D[i, j].GetValue() == val)
                    {
                        ans = i;
                        
                    }
                }
              
            }
            return ans;
        }
        //returns the index j of a cell
        public int GetIndexCol(int val)
        {
            int ans = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (this.grid2D[i, j].GetValue() == val)
                    {
                        ans = j;

                    }
                }

            }
            return ans;
        }

    }
}
