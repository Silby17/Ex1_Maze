using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Main started");
            MainRunner rm = new MainRunner();
            rm.startProgram();
            Console.ReadLine();
        }
    }
}
