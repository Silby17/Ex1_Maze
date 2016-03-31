using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public class ServerView : IView
    {
        public event EventHandler NewRequest;
    }
}
