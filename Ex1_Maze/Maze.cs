using System;
using System.Collections.Generic;

namespace Ex1_Maze
{
    
    public class Maze<T>
    {
        public string Name { get; set; }
        public string MazeStr { get; set; }
        public JPosition Start { get; set; }
        public JPosition End { get; set; }
        private int height { get; set; }
        private int width { get; set; }
        private Node<T>[,] grid2D;

        private int type { get; set; }


        /// <summary>
        /// Constructor for the Maze that recevies its sizes</summary>
        /// <param Name="height">Height of the Maze</param>
        /// <param Name="width">Width of the maze</param>
        public Maze(int height, int width)
        {
            this.height = height;
            this.width = width;
            Start = new JPosition();
            End = new JPosition();
            this.grid2D = new Node<T>[height, width];
        }


        /// <summary>
        /// Generates the maze with the given Parameters</summary>
        /// <param Name="name">Name of the Maze</param>
        /// <param Name="type">The Type of Maze</param>
        public void Generate(string name, int type)
        {
            this.Name = name;
            this.type = type;
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    this.grid2D[i, j] = new Node<T>(1, i, j);
                }
            }
        }

        public Node<T> GetNode(int i, int j)
        { return (this.grid2D[i, j]); }


        /// <summary>
        /// This function is called to Print the maze</summary>
        public void Print()
        {
            Console.WriteLine(this.Name);
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    Console.Write(grid2D[i, j].GetValue().ToString());
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MakeMazeString()
        {
            string mazeString = "";
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    mazeString = mazeString + grid2D[i, j].GetValue().ToString();
                }
            }
            this.MazeStr = mazeString;
            return MazeStr;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public void SetCell(int i, int j, int value)
        {
            // Console.WriteLine("Row = {0}  Col ={1}", Row ,Col);
            this.grid2D[i, j].SetValue(value);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int GetValue(int i, int j)
        {
            return (this.grid2D[i, j].GetValue());
        }


        /// <summary>
        /// Returns the 
        /// </summary>
        /// <returns></returns>
        public Node<T>[,] GetMaze()
        {
            return this.grid2D;
        }


        /// <summary>
        /// Returns the height of the maze</summary>
        /// <returns></returns>
        public int GetHeight()
        {
            return this.height;
        }


        /// <summary>
        /// Returns the width of the maze </summary>
        /// <returns></returns>
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
                    if (this.grid2D[i, j].GetValue() == val)
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



        public void SetSizesFromConfig(int h, int w)
        {
            this.height = h;
            this.width = w;
        }
    }
}