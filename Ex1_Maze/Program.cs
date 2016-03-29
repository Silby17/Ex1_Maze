using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dfs D = new Dfs();
            CreateableMaze maze = new CreateableMaze(5, 5, 1);
            D.create(maze);
            string user = Console.ReadLine();
        }
    }
}
