using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public delegate void NewViewChangeEvent(Object source, EventArgs e);
    public interface IView
    {
        event NewViewChangeEvent newInput;
        void PublishEvent();
        void DisplayText(string text);
        string GetText();
        void Start();
    }
}
