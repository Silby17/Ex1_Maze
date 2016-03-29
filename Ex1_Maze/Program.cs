using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class Program<T>
    {
        static void Main(string[] args)
        {
            Dfs<T> D = new Dfs<T>();
            CreateableMaze<T> maze = new CreateableMaze<T>(5, 5, 1);
            D.create(maze);
            string user = Console.ReadLine();
        }
    }
}
