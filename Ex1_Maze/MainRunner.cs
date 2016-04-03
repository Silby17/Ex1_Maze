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
            
            BestFS<int> B = new BestFS<int>();
            Maze maze = new Maze(5, 5);
            CreateableMaze<int> Cm = new CreateableMaze<int>(maze);
            SearchableMaze<int> Sm = new SearchableMaze<int>(maze);
            Cm.Generate("mazushshsh", 1);
            maze.print();
        }
    }
}
