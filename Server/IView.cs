using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IView
    {
        void DisplayData();
        void viewChanged(IObservable op, string msg);
    }
}
