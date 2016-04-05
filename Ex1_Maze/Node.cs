using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    //change NODE TO NODE<T>
    public class Node<T>
    {
        private int value;
        private int i;  
        private int j;
        private int cost;
        private Node<T> parent;

        public Node(int i, int j, Node<T> parent)
        {
            this.i = i;
            this.j = j;
            this.parent = parent;
            this.cost = new Random().Next(0, 20) ;
            this.value = 0;
        }

        public Node(int val)
        {
            //this.i = i;
            //this.j = j;
            //this.parent = parent;
           // this.cost = new Random().Next(0, 20);
            this.value = val;
        }

        public Node(int row, int col, int value, int cost)
        {
            this.i = row;
            this.j = col;
            this.cost = cost;
            this.value = value;
        }


        public Node()
        {
            //this.i = i;
            //this.j = j;
            //this.parent = parent;
             this.cost = new Random().Next(0, 20);
           // this.value = val;
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


        public Node<T> GetParent()
        {
            return this.parent;
        }


        public void SetValue(int v)
        {
            this.value = v;
        }


        public void SetParent(Node<T> s)
        {
            this.parent = s;
        }


        public void SetCost(int cost)
        {this.cost = cost;}
    }
}