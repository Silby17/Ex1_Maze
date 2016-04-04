using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.IO;

namespace Server2
{
    public class ClientPresenter : IPresenter
    {
        private IView view; //publisher
        private IModel model; // publisher


        /// <summary>
        /// This is the constructor method </summary>
        /// <param Name="v">The view for the client</param>
        /// <param Name="m">The main Model</param>
        public ClientPresenter(IView v, IModel m)
        {
            this.view = v;
            this.model = m;
            //Subsribes to events from the IView and IModel
            view.newInput += this.OnEventHandler;
            model.newModelChange += this.OnEventHandler;        
        }


        /// <summary>
        /// Handles any event that is received subsribed to</summary>
        /// <param Name="source">The source of the event</param>
        /// <param Name="e">Any event arguments sent by the event</param>
        public void OnEventHandler(object source, EventArgs e)
        {
            //Checks if if the event came from IView
            if (source is IView)
            {
                HandleViewEvent();
                
            }
            //Checks if event came from IModel
            else if(source is IModel)
            {
                HandleModelEvent();
            }
            
        }

        /// <summary>
        /// Handles any event from an IView object</summary>
        public void HandleViewEvent()
        {
            //Gets the String input from the views
            string command = view.GetStringInput();
            
            //Splits to a list of strings
            List<string> commandList = command.Split(' ').ToList();
            
            //Splits to a list of objects for passing to thread pool
            List<object> ol = commandList.ConvertAll(s => (object)s);

            //Sends thie parameters to the Execute Function in the Model
            this.model.ExecuteCommandalbe(ol);         
        }


        /// <summary>
        /// Handels any event from an IModel object</summary>
        public void HandleModelEvent()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string result = model.GetModelChange();
            //Maze m1 = JsonConvert.DeserializeObject<Maze>(result);
            //m1.SetSizesFromConfig();
            //m1.Print();
            view.DisplayData(result);
        }

        public void SetView(IView v)
        {
            throw new NotImplementedException();
        }
    }
}