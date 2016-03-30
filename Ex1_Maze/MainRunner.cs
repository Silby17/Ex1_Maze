using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class MainRunner
    {

        public void startProgram()
        {
            Console.WriteLine("Inside start method");
            string temp = Console.ReadLine();
            Dfs<int> D = new Dfs<int>();
            BestFS<int> B = new BestFS<int>();
            Maze maze = new Maze(5, 5, 1);
            CreateableMaze<int> Cm = new CreateableMaze<int>(maze);
            SearchableMaze<int> Sm = new SearchableMaze<int>(maze);
            D.create(Cm);
            string user = Console.ReadLine();
        }
    }
}
