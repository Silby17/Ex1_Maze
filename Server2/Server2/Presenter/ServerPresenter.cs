using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public class ServerPresenter : IPresenter
    {
        
        private IView view;
        private IModel model; 


        public ServerPresenter(IView v, IModel m)
        {
            this.view = v;
            this.model = m;
        }


        public void Start()
        {
            
        }




        public void handleCommandable(string data)
        {
            //options[data].execute();
        }
    }
}
