﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2.Options
{
    public class Option1 : ICommandable
    {
        public void Execute(List<object> args)
        {
            Console.WriteLine("Option 1 was chosen");
        }

    }
}
