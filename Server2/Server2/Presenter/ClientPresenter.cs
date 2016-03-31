using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    
    public class ClientPresenter : IPresenter
    {
        private IView view; //publisher
        private IModel model; // publisher
        

        /// <summary>
        /// This is the constructor method </summary>
        /// <param name="v">The view for the client</param>
        /// <param name="m">The main Model</param>
        public ClientPresenter(IView v, IModel m)
        {
            this.view = v;
            this.model = m;
            view.newInput += this.OnNotified;             
        }



        public void OnNotified(object source, EventArgs e)
        {
            Console.WriteLine("Received from the Client VIew");
        }




        public void handleCommandable(string data)
        {

        }

        public void Start()
        {
        }
    }
}
