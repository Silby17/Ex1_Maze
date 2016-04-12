using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    class BreadthFS<T> : ISearcher<T>
    {
        private Queue<Node<T>> q = new Queue<Node<T>>();
        private Solution<T> resultList = new Solution<T>(new List<Node<T>>());

        public Solution<T> Search(ISearchable<T> searchable)
        {
        
            Node<T> n = this.getPathBFS(searchable.GetMaze().GetStartPoint().GetRow(), 
                searchable.GetMaze().GetStartPoint().GetCol(), searchable);
                                                        
         while (null != n)
         {
             searchable.GetMaze().SetCell(n.GetRow(), n.GetCol(), 2);
             this.resultList.AddSolution(n);
             n = n.GetParent();
          }

        for (int i = 0; i < searchable.GetMaze().GetHeight(); i++)
        {
            for (int j = 0; j < searchable.GetMaze().GetWidth(); j++)
            {
                if (searchable.GetMaze().GetValue(i, j) == 5)
                {
                        searchable.GetMaze().SetCell(i, j, 0);
                }
            }
        }
            return resultList;

        }

        public Node<T> getPathBFS(int x, int y, ISearchable<T> searchable)
        {
            q.Enqueue(new Node<T>(x, y, null));
            //untill the queue is empty or found end node
            while (q.Count > 0)
            {
                Node <T> n = q.Dequeue();
                //got to end, return node
                if(searchable.GetMaze().GetEndPoint().GetRow() == n.GetRow() &&
                    searchable.GetMaze().GetEndPoint().GetCol() == n.GetCol())
                {
                    return n;
                }

                if (n.GetRow() != searchable.GetMaze().GetHeight() - 1)
                {
                    if (isFree(n.GetRow() + 1, n.GetCol(), searchable))
                    {   //mark as visited
                        searchable.GetMaze().SetCell(n.GetRow(), n.GetCol(), 5);
                        Node<T> nextNode = new Node<T>(n.GetRow() + 1, n.GetCol(), n);
                        q.Enqueue(nextNode);
                    }
                }

                if (n.GetRow() != 0)
                {
                    if (isFree(n.GetRow() - 1, n.GetCol(), searchable))
                    {
                        searchable.GetMaze().SetCell(n.GetRow(), n.GetCol(), 5);
                        Node<T> nextNode = new Node<T>(n.GetRow() - 1, n.GetCol(), n);
                        q.Enqueue(nextNode);
                    }
                }


                if (searchable.GetMaze().GetWidth() - 1 !=  n.GetCol())
                {
                    if (isFree(n.GetRow(), n.GetCol() + 1, searchable))
                    {
                        searchable.GetMaze().SetCell(n.GetRow(), n.GetCol(), 5);
                        Node<T> nextNode = new Node<T>(n.GetRow() , n.GetCol() + 1, n);
                        q.Enqueue(nextNode);
                    }
                }


                if (0 != n.GetCol())
                {
                    if (isFree(n.GetRow(), n.GetCol() - 1 ,searchable))
                    {
                        searchable.GetMaze().SetCell(n.GetRow(), n.GetCol(), 5);
                        Node<T> nextNode = new Node<T>(n.GetRow(), n.GetCol() - 1, n);
                        q.Enqueue(nextNode);
                    }
                }
            }
            return null;
        }


        public bool isFree(int x, int y, ISearchable<T> searchable)
        {
            if ((x >= 0 && x < searchable.GetMaze().GetWidth()) &&
                (y >= 0 && y < searchable.GetMaze().GetHeight()) &&
                (searchable.GetMaze().GetValue(x, y) == 0 ))
            {
                return true;
            }
            return false;
        }

    }
}
