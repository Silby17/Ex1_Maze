using System;
using System.Collections.Generic;

namespace Server2
{
    public delegate void NewModelChange(Object source, EventArgs e);

    public interface IModel
    {
        event NewModelChange newModelChange;
        void ExecuteCommandalbe(List<object> list);
        void CreateOptionsDictionary();
        void PublishEvent();
        string GetModelChange();
    }
}
