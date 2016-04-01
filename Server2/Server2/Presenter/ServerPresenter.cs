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

        /// <summary>
        /// Constructor Method</summary>
        /// <param name="v">The view for the Presenter</param>
        /// <param name="m">The Model for the Presenter</param>
        public ServerPresenter(IView v, IModel m)
        {
            this.view = v;
            this.model = m;
        }


        /// <summary>
        /// This function deals with and receives any event that is sent</summary>
        /// <param name="source">Object from the Publisher</param>
        /// <param name="e">Any event Arguments</param>
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
            string inputFromView = this.view.GetStringInput();
        }


        /// <summary>
        /// This function will get the message from the Model to
        /// send to the cliet in the JSOn format</summary>
        public void HandleModelEvent()
        {
            throw new NotImplementedException();
        }


        public void CreateOptionsDictionary()
        {
            throw new NotImplementedException();
        }
    }
}