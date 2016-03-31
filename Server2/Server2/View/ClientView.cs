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
        public event NewRequest newInput; //publisher


        public void Notif()
        {
            OnNewInput();
        }


        protected void OnNewInput()
        {
            if (newInput != null)
                newInput(this, EventArgs.Empty);
        }
    }
}
