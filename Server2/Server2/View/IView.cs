using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public delegate void NewRequest(Object source, EventArgs e);

    public interface IView
    {
        event NewRequest newInput;
        void Notif();
    }
}
