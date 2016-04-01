using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public class ClientView : IView
    {
        public event NewBiewChangeEvent newInput;



        public void OnNewViewChange(string str)
        {
            throw new NotImplementedException();
        }

        public void PublishEvent()
        {
            if (newInput != null)
            {
                newInput(this, EventArgs.Empty);
            }
        }
    }
}
