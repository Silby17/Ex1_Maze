using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public delegate void NewViewChangeEvent(Object source, EventArgs e);

    public interface IView
    {
        event NewViewChangeEvent newInput;
        void NewInput(string str);
        void PublishEvent();
        string GetStringInput();
    }
}
