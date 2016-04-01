using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex1_Maze
{
    public class Dfs<T>: ICreater<T>
    {
        private int height;
        private int width;
        private Maze maze;

        public Maze create(ICreateable<T> createable)
        {
            maze = createable.GetMaze();
            height = createable.GetHeight();
            width = createable.GetWidth();

            // 1 all over
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {   
                    maze.SetCell(i, j, 1); 
                }
                 

            int[] startEnd = RandomCreation<T>.getStartEndPoints(height, width);
            int start = startEnd[0];
            int end = startEnd[1];

            int startR = start / height;
            int startC = start % width;

            // Starting cell
            maze.SetCell(startR, startC, 0);
            

            //　Allocate the maze with recursive method
            recursion(startR, startC);
            PrintMaze(maze.GetMaze(), width, height);
            return maze;
        }



        public void recursion(int r, int c)
        {
            // 4 random directions
            int[] randDirs = generateRandomDirections();

            // Examine each direction
            for (int i = 0; i < randDirs.Length; i++)
            {
                switch (randDirs[i])
                {
                    case 1: // Up
                            // check for the state in up
                        if (r - 1 <= 0)
                            continue;
                        if (maze.GetValue(r - 2, c) !=0)
                        {
                            maze.SetCell(r - 2, c,0);
                            maze.SetCell(r - 1, c, 0);
                            recursion(r - 2, c);
                        }
                        break;
                    case 2: // Right
                            // check for the state in right
                        if (c + 1 >= width - 1)
                            continue;
                        if (maze.GetValue(r, c + 2) != 0)
                        {
                            maze.SetCell(r, c + 2,0);
                            maze.SetCell(r, c + 1,0);
                            recursion(r, c + 2);
                        }
                        break;
                    case 3: // Down
                            // check for the state in down
                        if (r + 1 >= height - 1)
                            continue;
                        if (maze.GetValue(r + 2, c) != 0)
                        {
                            maze.SetCell(r + 2, c, 0);
                            maze.SetCell(r + 1, c, 0);
                       
                            recursion(r + 2, c);
                        }
                        break;
                    case 4: // Left
                            // check for the state in left
                        if (c - 1 <= 0)
                            continue;
                        if (maze.GetValue(r, c - 2) != 0)
                        {
                            maze.SetCell(r, c - 2,0);
                            maze.SetCell(r, c - 1,0);
                            recursion(r, c - 2);
                        }
                        break;
                }
            }

        }

        /**
        * get an array with random directions
        */
        public int[] generateRandomDirections()
        {
            List<int> randoms = new List<int>();
            for (int i = 0; i < 4; i++)
                randoms.Add(i + 1);

            Random r = new Random();
            IEnumerable<int> fourRandom = randoms.OrderBy(x => r.Next()).Take(4);
            int[] array = fourRandom.ToArray();
            return array;
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

       
    }
}

