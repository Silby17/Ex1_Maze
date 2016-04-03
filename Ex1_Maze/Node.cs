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

        public Node(int i, int j, Node parent)
        {
            this.i = i;
            this.j = j;
            this.parent = parent;
            this.cost = new Random().Next(0, 20) + parent.GetCost();
            this.value = 0;
        }

        public Node(int value, int i, int j)
        {
            this.value = value;
            this.i = i;
            this.j = j;
            this.cost = new Random().Next(0, 20);
        }

        public int GetValue()
        {
            return this.value;
        }
        public int GetCost()
        {
            return this.cost;
        }

        public int GetRow()
        {
            return this.i;
        }

        public int GetCol()
        {
            return this.j;
        }

        public Node GetParent()
        {
            return this.parent;
        }
        public void SetValue(int v)
        {
            this.value = v;

        }

    }
}