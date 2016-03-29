using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class RandomCreation : ICreater
    {
        int height;
        int width;
        Node[] playMaze = new Node[n * m];
        Node[] mazeTable;
        int move;
        List<int> canGo = new List<int>();
        int start;
        int end;
        Random r2 = new Random();
        int rnd;

        public Node[,] create(ICreateable createable)
        {
            throw new NotImplementedException();
      //  maze = createable.GetMaze();
            height = createable.GetHeight();
            width = createable.GetWidth();


            int[] array = RandomCreation.getStartEndPoints(this.width, this.height);
            start = array[0];
            end = array[1];


            //get the whole mazeTable with start - 8 , end - 9;
            this.mazeTable = getStartMaze(start, end);

            //get an array to get line from start to end;
            Array.Copy(mazeTable, 0, playMaze, 0, m * n);
            move = start;
            int moveTo;

            List<int> upWall = new List<int>();
            List<int> downWall = new List<int>();
            List<int> rightWall = new List<int>();
            List<int> leftWall = new List<int>();
            List<int> mazeBorder = new List<int>();

            for (int i = 0; i < m; i++)
            {
                upWall.Add(i);
                downWall.Add(m * n - m + i);
            }

            for (int j = 1; j < n - 1; j++)
            {
                leftWall.Add(j * m);
                rightWall.Add(m * j + m - 1);
            }

            //find a way from start to end point
            while (move != end)
            {
                canGo.Clear();

                //up - start point at up

                if (upWall.Contains(move))
                {
                    moveTo = this.MoveFromUpWall();
                }
                else
                {
                    //down
                    if (downWall.Contains(move))
                    {
                        moveTo = this.MoveFromDownWall();
                    }
                    else
                    {
                        //right
                        if (rightWall.Contains(move))
                        {
                            moveTo = this.MoveFromRightWall();
                        }
                        else
                        {
                            //left
                            if (leftWall.Contains(move))
                            {
                                moveTo = this.MoveFromLeftWall();
                            }
                            else
                            {
                                //just - middle of maze
                                moveTo = this.MoveFromMiddle();
                            }
                        }
                    }
                }

                if (moveTo == 1)
                {
                    continue;
                }
                else
                {// == 2
                    break;
                }
            }       //end of while

            for (int i = 0; i < m * n; i++)
            {
                Console.Write(playMaze[i]);
                if (i % m == m - 1)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("end of random creat");

            return 1;

        }


        public int[] getStartMaze(int start, int end)
        {

            //get the whole mazeTable with start - 8 , end - 9;
            int[] mazeTable = new int[m * n];
            for (int i = 0; i < m * n; i++)
            {
                if (i == start)
                {
                    mazeTable[i] = 8;
                    continue;
                }
                if (i == end)
                {
                    mazeTable[i] = 9;
                    continue;
                }
                mazeTable[i] = 1;
            }

            return mazeTable;
        }


        //if finish return 2 - need to break
        //if moved return 1 - continue
        public int MoveFromUpWall()
        {

            //up-left-corner
            if (move == 0)
            {
                if (playMaze[move + 1] == 1)
                {
                    canGo.Add(move + 1);
                }
                if (playMaze[move + m] == 1)
                {
                    canGo.Add(move + m);
                }

                if (playMaze[move + 1] == 9 || playMaze[move + m] == 9)
                {
                    return 2;
                }

                if (canGo.Count == 0)
                {
                    Array.Copy(mazeTable, 0, playMaze, 0, m * n);
                    move = start;
                }
                else
                {
                    //moveeeee
                    rnd = r2.Next(canGo.Count);
                    move = canGo[rnd];
                    playMaze[move] = 0;
                }
                return 1;
            }

            //up-right-corner
            if (move == m - 1)
            {
                if (playMaze[move - 1] == 1)
                {
                    canGo.Add(move - 1);
                }
                if (playMaze[move + m] == 1)
                {
                    canGo.Add(move + m);
                }

                if (playMaze[move - 1] == 9 || playMaze[move + m] == 9)
                {
                    return 2;
                }

                if (canGo.Count == 0)
                {
                    Array.Copy(mazeTable, 0, playMaze, 0, m * n);
                    move = start;
                }
                else
                {
                    //moveeeee
                    rnd = r2.Next(canGo.Count);
                    move = canGo[rnd];
                    playMaze[move] = 0;

                }
                return 1;
            }


            //midlle - up


            if (playMaze[move + m] == 1)
            {
                canGo.Add(move + m);
            }
            if (playMaze[move - 1] == 1)
            {
                canGo.Add(move - 1);
            }
            if (playMaze[move + 1] == 1)
            {
                canGo.Add(move + 1);
            }

            if (playMaze[move + m] == 9 || playMaze[move - 1] == 9 || playMaze[move + 1] == 9)
            {
                return 2;
            }

            if (canGo.Count == 0)
            {
                Array.Copy(mazeTable, 0, playMaze, 0, m * n);
                move = start;
            }
            else
            {
                rnd = r2.Next(canGo.Count);
                move = canGo[rnd];
                playMaze[move] = 0;
            }
            return 1;
        }




        //if finish return 2 - need to break
        //if moved return 1 - need to continue
        public int MoveFromDownWall()
        {
            //lower-left-corner
            if (move == m * n - m)
            {
                if (playMaze[move + 1] == 1)
                {
                    canGo.Add(move + 1);
                }
                if (playMaze[move - m] == 1)
                {
                    canGo.Add(move - m);
                }

                if (playMaze[move + 1] == 9 || playMaze[move - m] == 9)
                {
                    return 2;
                }

                if (canGo.Count == 0)
                {
                    Array.Copy(mazeTable, 0, playMaze, 0, m * n);
                    move = start;
                }
                else
                {
                    //moveeeee
                    rnd = r2.Next(canGo.Count);
                    move = canGo[rnd];
                    playMaze[move] = 0;
                }
                return 1;
            }

            //lower-right-corner
            if (move == m * n - 1)
            {
                if (playMaze[move - 1] == 1)
                {
                    canGo.Add(move - 1);
                }
                if (playMaze[move - m] == 1)
                {
                    canGo.Add(move - m);
                }

                if (playMaze[move - 1] == 9 || playMaze[move - m] == 9)
                {
                    return 2;
                }

                if (canGo.Count == 0)
                {
                    Array.Copy(mazeTable, 0, playMaze, 0, m * n);
                    move = start;
                }
                else
                {
                    //moveeeee
                    rnd = r2.Next(canGo.Count);
                    move = canGo[rnd];
                    playMaze[move] = 0;

                }
                return 1;
            }


            //midlle - lower


            if (playMaze[move - m] == 1)
            {
                canGo.Add(move - m);
            }
            if (playMaze[move - 1] == 1)
            {
                canGo.Add(move - 1);
            }
            if (playMaze[move + 1] == 1)
            {
                canGo.Add(move + 1);
            }

            if (playMaze[move + 1] == 9 || playMaze[move - m] == 9 || playMaze[move - 1] == 9)
            {
                return 2;
            }

            if (canGo.Count == 0)
            {
                Array.Copy(mazeTable, 0, playMaze, 0, m * n);
                move = start;
            }
            else
            {
                rnd = r2.Next(canGo.Count);
                move = canGo[rnd];
                playMaze[move] = 0;
            }
            return 1;
        }

        //if finish return 2 - need to break
        //if moved return 1 - need to continue
        public int MoveFromRightWall()
        {

            //midlle - right

            if (playMaze[move - m] == 1)
            {
                canGo.Add(move - m);
            }
            if (playMaze[move - 1] == 1)
            {
                canGo.Add(move - 1);
            }
            if (playMaze[move + m] == 1)
            {
                canGo.Add(move + m);
            }

            if (playMaze[move - m] == 9 || playMaze[move - 1] == 9 || playMaze[move + m] == 9)
            {
                return 2;
            }

            if (canGo.Count == 0)
            {
                Array.Copy(mazeTable, 0, playMaze, 0, m * n);
                move = start;
            }
            else
            {
                rnd = r2.Next(canGo.Count);
                move = canGo[rnd];
                playMaze[move] = 0;
            }
            return 1;

        }


        //if stack return 2 - need to break
        //if moved return 1 - need to continue
        public int MoveFromLeftWall()
        {
            //midlle - left


            if (playMaze[move - m] == 1)
            {
                canGo.Add(move - m);
            }
            if (playMaze[move + 1] == 1)
            {
                canGo.Add(move + 1);
            }
            if (playMaze[move + m] == 1)
            {
                canGo.Add(move + m);
            }

            if (playMaze[move - m] == 9 || playMaze[move + 1] == 9 || playMaze[move + m] == 9)
            {
                return 2;
            }

            if (canGo.Count == 0)
            {
                Array.Copy(mazeTable, 0, playMaze, 0, m * n);
                move = start;
            }
            else
            {
                rnd = r2.Next(canGo.Count);
                move = canGo[rnd];
                playMaze[move] = 0;
            }
            return 1;
        }

        //if finish return 2 - need to break
        //if moved return 1 - need to continue
        public int MoveFromMiddle()
        {
            if (playMaze[move - m] == 1)
            {
                canGo.Add(move - m);
            }
            if (playMaze[move + 1] == 1)
            {
                canGo.Add(move + 1);
            }
            if (playMaze[move + m] == 1)
            {
                canGo.Add(move + m);
            }
            if (playMaze[move - 1] == 1)
            {
                canGo.Add(move - 1);
            }

            if (playMaze[move - m] == 9 || playMaze[move - 1] == 9 || playMaze[move + m] == 9 || playMaze[move + 1] == 9)
            {
                return 2;
            }

            if (canGo.Count == 0)
            {
                Array.Copy(mazeTable, 0, playMaze, 0, m * n);
                move = start;
            }
            else
            {
                rnd = r2.Next(canGo.Count);
                move = canGo[rnd];
                playMaze[move] = 0;
            }
            return 1;
        }


        public static int[] getStartEndPoints(int height, int width)
        {
            //get boreder to list
            List<int> upWall = new List<int>();
            List<int> downWall = new List<int>();
            List<int> rightWall = new List<int>();
            List<int> leftWall = new List<int>();
            List<int> mazeBorder = new List<int>();

            for (int i = 0; i < width; i++)
            {
                upWall.Add(i);
                downWall.Add(width * height - width + i);
            }

            for (int j = 1; j < height - 1; j++)
            {
                leftWall.Add(j * width);
                rightWall.Add(width * j + width - 1);
            }

            mazeBorder.AddRange(rightWall);
            mazeBorder.AddRange(downWall);
            mazeBorder.AddRange(leftWall);

            //get start and end points
            Random r = new Random();
            IEnumerable<int> threeRandom = mazeBorder.OrderBy(x => r.Next()).Take(2);
            int[] array = threeRandom.ToArray();
            return array;
        }

       
    }


}
