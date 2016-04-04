using System.Web.Script.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System;


namespace Server2
{
    public class ServerPresenter : IPresenter
    {
        private IView view; //publisher
        private IModel model; //publisher

        /// <summary>
        /// Constructor Method</summary>
        /// <param Name="v">The view for the Presenter</param>
        /// <param Name="m">The Model for the Presenter</param>
        public ServerPresenter(IModel m)
        {
            this.model = m;
            //Subscribe to events from the Model
            model.newModelChange += this.OnEventHandler;
        }

        public void SetView(IView v)
        {
            this.view = v;
            //Subscribe to events from the View
            view.newInput += this.OnEventHandler;
        }


        /// <summary>
        /// This function deals with and receives any event that is sent</summary>
        /// <param Name="source">Object from the Publisher</param>
        /// <param Name="e">Any event Arguments</param>
        public void OnEventHandler(object source, EventArgs e)
        {
            if(source is IView)
            {
                HandleViewEvent();
            }
            else if(source is IModel)
            {
                HandleModelEvent();
            }
        }


        /// <summary>
        /// This Function will get the data that the view wants to 
        /// send to the Presenter </summary>
        public void HandleViewEvent()
        {
            //Gets the new string input from the Client
            string newCommand = view.GetStringInput();
            
            //Splits to a list of strings
            List<string> commandList = newCommand.Split(' ').ToList();

            //Splits to a list of objects for passing to thread pool
            List<object> ol = commandList.ConvertAll(s => (object)s);

            this.model.ExecuteCommandalbe(ol);
        }


        /// <summary>
        /// This function will get the message from the Model to
        /// send to the cliet in the JSOn format</summary>
        public void HandleModelEvent()
        {
            string result = model.GetModelChange();
            view.DisplayData(result);
        }
    }
}