﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
        public interface ISearcher
        {
            // the search method
            Solution<T> Search(ISearchable searchable);
            // get how many nodes were evaluated by the algorithm
            int getNumberOfNodesEvaluated();
            
        } 
}
