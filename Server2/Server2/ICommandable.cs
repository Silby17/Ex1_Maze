﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public interface ICommandable
    {
        void Execute(List<object> args);
    }
}
