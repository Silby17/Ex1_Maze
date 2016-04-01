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
        private Dictionary<string, ICommandable> options;


        /// <summary>
        /// This is the constructor method </summary>
        /// <param name="v">The view for the client</param>
        /// <param name="m">The main Model</param>
        public ClientPresenter(IView v, IModel m)
        {
            this.view = v;
            this.model = m;
            view.newInput += this.OnEventHandler;
            model.newModelChange += this.OnEventHandler;        
        }



        public void OnEventHandler(object source, EventArgs e)
        {
            if (source is IView)
            {
                Console.WriteLine("Received from the Client VIew");
            }
            else if(source is IModel)
            {
                Console.WriteLine("Received Event from Model");
            }
            
        }




        public void handleCommandable(string data)
        {

        }

        public void CreateOptionsDictionary()
        {
            this.options = new Dictionary<string, ICommandable>();
            options.Add("1", new Options.Option1());
            options.Add("2", new Options.Option2());
            options.Add("3", new Options.Option3());
            options.Add("4", new Options.Option4());
            options.Add("5", new Options.Option5());
        }
    }
}
