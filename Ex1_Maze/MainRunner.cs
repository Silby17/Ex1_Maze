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
            
            Maze<int> maze = new Maze<int>(5, 5);
            GeneralMaze<int> Cm = new GeneralMaze<int>(maze);
            Cm.Generate("mazushshsh", 1);
           // Cm.Solve("nava", 1);
            maze.Print();
        }
    }
}
