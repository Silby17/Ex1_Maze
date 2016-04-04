using System;


namespace Server2
{
    public delegate void NewViewChangeEvent(Object source, EventArgs e);

    public interface IView
    {
        event NewViewChangeEvent newInput;
        void OnNewInput(string str);
        void DisplayData(string data);
        string GetStringInput();
        void PublishEvent();      
    }
}
