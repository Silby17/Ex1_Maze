using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Dfs: ICreater
    {
        public int height;
        public int width;
        public Node[,] maze;

        public Node[,] create(ICreateable createable)
        {
            // throw new NotImplementedException();

           maze = createable.GetMaze();
            height = createable.GetHeight();
            width = createable.GetWidth();

            // 1 all over
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    //  maze[i, j].SetValue(1);
                    maze[i, j] = new Node(1);
                }
                 

            int[] startEnd = RandomCreation.getStartEndPoints(height, width);
            int start = startEnd[0];
            int end = startEnd[1];

            int startR = start / height;
            int startC = start % width;

            // Starting cell
            maze[startR, startC] = new Node(0);

            //　Allocate the maze with recursive method
            recursion(startR, startC);
            PrintMaze(maze, width, height);
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
                        if (maze[r - 2, c].GetValue() !=0)
                        {
                            maze[r - 2, c].SetValue(0);
                            maze[r - 1, c].SetValue(0);
                            recursion(r - 2, c);
                        }
                        break;
                    case 2: // Right
                            // check for the state in right
                        if (c + 1 >= width - 1)
                            continue;
                        if (maze[r, c + 2].GetValue() != 0)
                        {
                            maze[r, c + 2].SetValue(0);
                            maze[r, c + 1].SetValue(0);
                            recursion(r, c + 2);
                        }
                        break;
                    case 3: // Down
                            // check for the state in down
                        if (r + 1 >= height - 1)
                            continue;
                        if (maze[r + 2, c].GetValue() != 0)
                        {
                            maze[r + 2, c].SetValue(0);
                            maze[r + 1, c].SetValue(0);
                            recursion(r + 2, c);
                        }
                        break;
                    case 4: // Left
                            // check for the state in left
                        if (c - 1 <= 0)
                            continue;
                        if (maze[r, c - 2].GetValue() != 0)
                        {
                            maze[r, c - 2].SetValue(0);
                            maze[r, c - 1].SetValue(0);
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
                   //onsole.Write(maze[i, j]);
                    Console.Write(maze[i, j].GetValue());

                }
                Console.WriteLine();
            }

        }

       
    }
}

