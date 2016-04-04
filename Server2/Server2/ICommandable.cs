using System;
using System.Collections.Generic;


namespace Server2
{
    public delegate void ExecutionDone(Object source, EventArgs e);

    public interface ICommandable
    {
        event ExecutionDone execDone;
        string Execute(List<object> args);
        void PublishEvent();
    }
}