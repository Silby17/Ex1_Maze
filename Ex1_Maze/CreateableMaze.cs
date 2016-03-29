using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class CreateableMaze : ICreateable
    {
    //  public Node[,] maze;
        public int height;
        public int width;
        public int type;

        public CreateableMaze(int height, int width, int type)
        {
        //  maze = new Node[height, width];
            this.height = height;
            this.width = width;
            this.type = type;
        }
        public int GetHeight()
        {
            return this.height;
        }

        public Node[,] GetMaze()
        {
            return new Node[height, width];
        }

        public int GetWidth()
        {
            return this.width;
        }

        int ICreateable.GetType()
        {
            return this.type;

        }
    }
}
