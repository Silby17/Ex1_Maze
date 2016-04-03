using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    //change NODE TO NODE<T>
    public class Node
    {
        private int value;
        public int row {get; set;}
        public int col { get; set; }
        private int cost;
        private Node parent;

        public Node(int i, int j, Node parent)
        {
            this.row = i;
            this.col = j;
            this.parent = parent;
            this.cost = new Random().Next(0, 20) + parent.GetCost();
            this.value = 0;
        }


        public Node(int value, int i, int j)
        {
            this.value = value;
            this.row = i;
            this.col = j;
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
            return this.row;
        }

        public int GetCol()
        {
            return this.col;
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