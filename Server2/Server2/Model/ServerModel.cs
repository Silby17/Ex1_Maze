﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public class ServerModel : IModel
    {
        public event NewModelChange newModelChange;

        private Dictionary<string, ICommandable> options;


        public ServerModel()
        {
            
        }

        

        public void OnModelChange()
        {
            throw new NotImplementedException();
        }
    }
}