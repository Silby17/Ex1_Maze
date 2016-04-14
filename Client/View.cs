using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class View : IView
    {
        public event NewViewChangeEvent newInput;
        private string toSend;

        public View()
        {

        }

        public void DisplayText(string text)
        {
            Console.WriteLine(text);
        }

        public void Start()
        {
            Thread sender = new Thread(SendThread);
            sender.Start();
        }


        public void SendThread()
        {
            while (true)
            {
                string toSend = Console.ReadLine();
                if (toSend != "exit")
                {
                    this.toSend = toSend;
                    PublishEvent();
                }
                else
                {
                    this.toSend = toSend;
                    PublishEvent();
                    break;
                }
            }
        }



        public string GetText()
        {
            string text = this.toSend;
            this.toSend = "";
            return text;
        }




        public void PublishEvent()
        {
            if (newInput != null)
            {
                newInput(this, EventArgs.Empty);
            }
        }
    }
}
