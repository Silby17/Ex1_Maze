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
        public event NewBiewChangeEvent newInput;

        event NewBiewChangeEvent IView.newInput
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void OnNewViewChange(string str)
        {
            
        }


        public void PublishEvent()
        {
            
        }

        string IView.GetStringInput()
        {
            throw new NotImplementedException();
        }

        void IView.NewInput(string str)
        {
            throw new NotImplementedException();
        }

        void IView.PublishEvent()
        {
            throw new NotImplementedException();
        }
    }
}
