using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    //change NODE TO NODE<T>
    public class Node
    {
        private int value;

        public Node(int v)
        {
            this.value = v;
        }

        public int GetValue()
        {
            return this.value;
        }
        public void SetValue(int v)
        {
            this.value = v;

        }

    }
}