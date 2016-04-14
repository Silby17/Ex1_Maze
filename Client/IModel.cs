using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public delegate void NewModelChange(Object source, EventArgs e);

    public interface IModel
    {
        event NewModelChange newModelChange;
        void PublishEvent();
        string GetMessageFromServer();
        void Start();
        void SendThread(string textToSend);
    }
}
