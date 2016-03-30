using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientPresenter<T> : IPresenter
    {
        IModel<T> model;
        IView view;
        Dictionary<string, ICommandable> options;

        ClientPresenter(IModel<T> iM, IView iV)
        {
            this.model = iM;
            this.view = iV;
            options = new Dictionary<string, ICommandable>();
            options.Add("1", new Options.Option1());
            options.Add("2", new Options.Option2());
            options.Add("3", new Options.Option3());
            options.Add("4", new Options.Option4());
            options.Add("5", new Options.Option5());
        }
    }
}
