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
        private int i;  
        private int j;
        private int cost;
        private Node parent;

        public Node(int value)
        {
            this.value = value;
        }

        public Node(int i, int j, Node parent)
        {
            this.i = i;
            this.j = j;
            this.parent = parent;
        }

        public Node(int value, int i, int j)
        {
            this.value = value;
            this.i = i;
            this.j = j;
        }

        public int GetValue()
        {
            return this.value;
        }

        public int GetRow()
        {
            return this.i;
        }

        public int GetCol()
        {
            return this.j;
        }

        public void SetValue(int v)
        {
            this.value = v;

        }

    }
}