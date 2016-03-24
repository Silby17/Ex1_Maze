using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Maze
{
    class CreateableMaze : ICreateable
    {
        private Maze currentMaze;
       
        public void create(ICreateable createable)
        {   //dfs
            if(1 == createable.getType())
            {
                  
            }
            //random
            if(0 == createable.getType())
            {
               
            }
            throw new NotImplementedException();
        }

        public int getType()
        {
            throw new NotImplementedException();
        }

        public int getColums()
        {
            throw new NotImplementedException();
        }

        public int getRows()
        {
            throw new NotImplementedException();
        }
    }
}
