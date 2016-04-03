using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Server2
{
    public class Dfs<T>: ICreater<T>
    {
        private int height;
        private int width;
        private Maze maze;

        public void create(ICreateable<T> createable)
        {
            maze = createable.GetMaze();
            height = createable.GetHeight();
            width = createable.GetWidth();
     
            //initialize stack to work with
            Stack<Node> s = new Stack<Node>();
            s.Push(createable.GetStartPoint());
            int i;
            int j;

            //check till the stack is empty
            while (0 != s.Count)
            {
                Node current = s.Pop();
                i = current.GetRow();
                j = current.GetCol();

                //check for up move
                if (i - 1 > 0)
                {
                    if (0 != maze.GetValue(i - 2, j))
                    {
                        maze.SetCell(i - 2, j ,0);
                        maze.SetCell(i - 1, j, 0);
                       //the parent of the new node is the current 
                        s.Push(new Node(i - 2, j, current));
                    }
                }

                // check for the state in right
                if (j + 1 < width - 1)
                {
                    if (0 != maze.GetValue(i, j + 2))
                    {
                        maze.SetCell(i, j + 2, 0);
                        maze.SetCell(i, j + 1, 0);
                        s.Push(new Node(i, j + 2, current));
                    }
                }

                // check for the state in down
                if (i + 1 < height - 1)
                {
                    if (maze.GetValue(i + 2, j) != 0)
                    {
                        maze.SetCell(i + 2, j, 0);
                        maze.SetCell(i + 1, j, 0);
                        s.Push(new Node(i + 2, j, current));
                    }
                }

                // check for the state in left
                if (j - 1 > 0)
                {
                    if (maze.GetValue(i, j - 2) != 0)
                    {
                        maze.SetCell(i, j - 2, 0);
                        maze.SetCell(i, j - 1, 0);
                        s.Push(new Node(i, j - 2, current));
                    }
                }

            }
        }
    }
}

