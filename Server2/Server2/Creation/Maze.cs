using System;
using System.Collections.Generic;

namespace Server2
{
    public class Maze
    {
        private Node[,] grid2D;
        private int height;
        private int width;
        private int type;
        public string Name { get; set; }
        public string MazeStr { get; set; }
        public JPosition Start { get; set; }
        public JPosition End { get; set; }


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
            this.grid2D = new Node[height, width];
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
                    this.grid2D[i, j] = new Node(1, i, j);
                }
            }
        }


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


        public void MakeMazeString()
        {
            string mazeString = "";
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    mazeString = mazeString+  grid2D[i, j].GetValue().ToString();
                }
            }
            this.MazeStr = mazeString;
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
           // Console.WriteLine("row = {0}  col ={1}", row ,col);
            this.grid2D[i, j].SetValue(value);
        }

        public int GetValue(int i, int j)
        {
           return (this.grid2D[i, j].GetValue());
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


        
    }
}
