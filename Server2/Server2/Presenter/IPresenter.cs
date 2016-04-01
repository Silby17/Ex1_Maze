using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    
    public interface IPresenter
    {
        void OnEventHandler(object source, EventArgs e);
        void HandleViewEvent();
        void HandleModelEvent();
        void CreateOptionsDictionary();
    }
}
