﻿using System;
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
        public Maze(int n, int m)
        {
            this.grid2D = new Node[n, m];
        }
 
    }
}
