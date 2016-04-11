using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Ex1_Maze;

namespace Server2
{
    public delegate void ExecutionDone(Object source, EventArgs e);

    public interface ICommandable
    {
        event ExecutionDone execDone;
        void Execute(List<object> args, Socket client,
            Dictionary<string, GeneralMaze<int>> list);
        void PublishEvent();
        Socket GetClientSocket();
    }
}