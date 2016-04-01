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
        private string commandToSend;

        public event NewViewChangeEvent newInput;

        /// <summary>
        /// Simple Constructor Method/// </summary>
        public ClientView()
        {}



        public void NewInput(string str)
        {
            commandToSend = str;
            PublishEvent();
        }


        public void PublishEvent()
        {
            if (newInput != null)
            {
                newInput(this, EventArgs.Empty);
            }
        }

        public string GetStringInput()
        {
            return this.commandToSend;
        }
    }
}
