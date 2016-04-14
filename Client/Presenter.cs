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

        public Presenter()
        {
            this.model = new Model();
            this.view = new View();
            this.model.newModelChange += OnEventHandler;
            this.view.newInput += OnEventHandler;
        }

        public void Start()
        {
            this.model.Start();
            this.view.Start();
        }


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



        public void HandleModelEvent()
        {
            string msg = this.model.GetMessageFromServer();
            this.view.DisplayText(msg);
        }



        public void HandleViewEvent()
        {
            string msg = this.view.GetText();
            this.model.SendThread(msg);
        }




    }
}
