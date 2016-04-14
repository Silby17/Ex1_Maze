using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Presenter : IPresenter
    {
        IModel model;
        IView view;



        /// <summary>
        /// Default Constructor</summary>
        public Presenter()
        {
            this.model = new Model();
            this.view = new View();
            this.model.newModelChange += OnEventHandler;
            this.view.newInput += OnEventHandler;
        }


        /// <summary>
        /// Starts the running of the presenter</summary>
        public void Start()
        {
            this.model.Start();
            this.view.Start();
        }


        /// <summary>
        /// Handels any event received</summary>
        /// <param name="source">Sender of the event</param>
        /// <param name="e">Any params from the event</param>
        public void OnEventHandler(object source, EventArgs e)
        {
            if (source is IModel)
            {
                HandleModelEvent();
            }
            else if (source is IView)
            {
                HandleViewEvent();
            }
        }


        /// <summary>
        /// Handled the events from the model</summary>
        public void HandleModelEvent()
        {
            string msg = this.model.GetMessageFromServer();
            this.view.DisplayText(msg);
        }


        /// <summary>
        /// Handels the events from the view</summary>
        public void HandleViewEvent()
        {
            string msg = this.view.GetText();
            this.model.SendThread(msg);
        }
    }
}