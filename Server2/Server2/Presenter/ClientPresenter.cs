using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public class ClientPresenter : IPresenter
    {
        private IView view;
        private IModel model;
      
        /// <summary>
        /// This is the constructor method </summary>
        /// <param name="v">The view for the client</param>
        /// <param name="m">The main Model</param>
        public ClientPresenter(IView v, IModel m)
        {
            this.view = v;
            this.model = m;
        }

        public void ReceivedEvent(object source, EventArgs e)
        {
            if(source is IView)
            {
                Console.WriteLine("Event from IVIew Baby");
            }
        }




        public void handleCommandable(string data)
        {

        }

        public void Start()
        {
        }
    }
}
