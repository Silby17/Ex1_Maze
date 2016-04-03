using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public class RandomCreation<T> 
    {
        private int height;
        private int width;
        private Maze maze;

        //By prim algo
        public void create(ICreateable<T> createable)
        {
            maze = createable.GetMaze();
            height = createable.GetHeight();
            width = createable.GetWidth();
            List<Node> primList = new List<Node>();
            primList.Add(createable.GetStartPoint());

            while (primList.Count > 0)
            {
                primList = primList.Distinct().ToList();
                this.getNeighbors(primList);
            }
        }

        public List<Node> getNeighbors(List<Node> neighbors)
        {
            int rundomNumber = new Random().Next(neighbors.Count);
            //choose a randon neighbor to go to
            Node current = neighbors[rundomNumber];
            maze.SetCell(current.GetRow(), current.GetCol(), 0);

            //check if ther are parents to mark the point between
            if (current.GetParent() != null)
            {
                int colBetwen = (current.GetParent().GetCol() + current.GetCol()) / 2;
                int rowBetwen = (current.GetParent().GetRow() + current.GetRow()) / 2;
                if (colBetwen < 0)
                {
                    colBetwen *= -1;
                }

                if (rowBetwen < 0)
                {
                    rowBetwen *= -1;
                }
            
                this.maze.SetCell(rowBetwen, colBetwen, 0);
            }

            //remove from list
            neighbors.Remove(current);

            int col = current.GetCol();
            int row = current.GetRow();
           
            //up
            if (row - 2 >= 0 && this.maze.GetValue(row - 1, col) == 1 &&
                this.maze.GetValue(row - 2, col) == 1)
            {
                neighbors.Add(new Node(row - 2, col, current));
            }

            //down
            if (row + 2 < this.height && this.maze.GetValue(row + 1, col) == 1 &&
                this.maze.GetValue(row + 2, col) == 1)
            {
                neighbors.Add(new Node(row + 2, col, current));
            }

            //left
            if (col - 2 >= 0 && this.maze.GetValue(row, col - 1) == 1 &&
                this.maze.GetValue(row, col - 2) == 1)
            {
                neighbors.Add(new Node(row, col - 2, current));
            }

            //right
            if (col + 2 < this.width && this.maze.GetValue(row, col + 1) == 1 &&
               this.maze.GetValue(row, col + 2) == 1)
            { 
                neighbors.Add(new Node(row, col +2, current));
            }
            return neighbors;
        }

    }
}
    
