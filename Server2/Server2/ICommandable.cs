using System.Collections.Generic;


namespace Server2
{
    public interface ICommandable
    {
        void Execute(List<object> args);
    }
}