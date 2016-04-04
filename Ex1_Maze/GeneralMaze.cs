﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class GeneralMaze<T> : ICreateable<T>, ISearchable<T>
    {

        private Maze<T> maze;

        public GeneralMaze(Maze<T> maze)
        {
            this.maze = maze;
        }

        //[type] - 0 for random and 1 for DFS
        public void Generate(string name, int type)
        {
            this.maze.Generate(name, type);
            //DFS
            if (1 == type)
            {
                Dfs<T> D = new Dfs<T>();
                D.create(new GeneralMaze<T>(this.maze));
            }
            //Random
            if (0 == type)
            {
                RandomCreation<T> R = new RandomCreation<T>();
                R.create(new GeneralMaze<T>(this.maze));
            }
        }

        //- 0 for Breadth first and 1 for Best first
        public void Solve(string name, int type)
        {
            //Best first
            if (1 == type)
            {
                BestFS<T> B = new BestFS<T>();
                B.Search(new GeneralMaze<T>(maze));
            }
            //Breadth first
            if (0 == type)
            {
                // BreadthFS<int> B = new BreadthFS<int>();
                //B.Search(new GeneralMaze<int>(maze));
            }

        }


        public int GetHeight()
        {
            return this.maze.GetHeight();
        }

        public Maze<T> GetMaze()
        {
            return this.maze;
        }

        //returns the grid itself
        public Node<T>[,] GetGrid()
        {
            return this.maze.GetMaze();
        }

        public int GetWidth()
        {
            return this.maze.GetWidth();
        }


        public Node<T> GetStartPoint()
        {
            return (new Node<T>(0, 0, new Random().Next(0, GetHeight() - 1)));
        }

        public Node<T> GetEndPoint()
        {
            return (new Node<T>(0, new Random().Next(0, GetWidth() - 1), GetHeight() - 1));

        }

        public Node<T> getInitialState()
        {
            return new Node<T>(GetStartPoint().GetValue());
        }

        public Node<T> getGoalState()
        {
            return new Node<T>(GetEndPoint().GetValue());
        }
        /// <summary>
        /// returns a list of all possibles moves
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<Node<T>> getAllPossibleStates(Node<T> n)
        {
            List<Node<T>> possibleStates = new List<Node<T>>();
            int i = n.GetRow();
            int j = n.GetCol();

            // cheack up
            if ((this.maze.GetValue(i, j - 1) != 1) && (j >= 0))
            {
                possibleStates.Add(this.maze.GetNode(i, j - 1));
            }
            //down
            if ((this.maze.GetValue(i, j + 1) != 1) && (j <= GetHeight() - 1))
            {
                possibleStates.Add(this.maze.GetNode(i, j + 1));
            }
            //left
            if ((this.maze.GetValue(i - 1, j) != 1) && (i >= 0))
            {
                possibleStates.Add(this.maze.GetNode(i - 1, j));
            }
            //right
            if ((this.maze.GetValue(i + 1, j) != 1) && (i <= GetWidth() - 1))
            {
                possibleStates.Add(this.maze.GetNode(i + 1, j));
            }

            return possibleStates;
        }



    }
}
