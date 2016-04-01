using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public class ServerModel : IModel
    {
        public event NewModelChange newModelChange;

        public void TESTMODELEVENT()
        {
            PublishEvent();
        }


        public void OnModelChange()
        {
            throw new NotImplementedException();
        }

        public void PublishEvent()
        {
            if(newModelChange != null)
            {
                newModelChange(this, EventArgs.Empty);
            }
        }
    }
}