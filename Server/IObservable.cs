﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IObservable
    {
        void addObserver(Observer ob);
        void notifyObservers();
    }
}
