using System;
using System.Net.Sockets;

namespace Server2
{
    public delegate void NewViewChangeEvent(Object source, EventArgs e);

    public interface IView
    {
        event NewViewChangeEvent newInput;
        void OnNewInput(string str, Socket client);
        string GetStringInput();
        Socket GetClient();
        void PublishEvent();
    }
}