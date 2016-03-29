using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class RandomCreation<T> : ICreater<T>
    {
        public Node[,] create(ICreateable<T> createable)
        {
            throw new NotImplementedException();
        }

        internal static int[] getStartEndPoints(int height, int width)
        {
            throw new NotImplementedException();
        }
    }
}