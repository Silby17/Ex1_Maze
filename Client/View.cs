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


        /// <summary>
        /// Default Constructor</summary>
        public View()
        {}


        /// <summary>
        /// Displays and text received on the screen</summary>
        /// <param name="text">Text to be displayed</param>
        public void DisplayText(string text)
        { Console.WriteLine(text); }



        /// <summary>
        /// Starts the Thread that will send to the server</summary>
        public void Start()
        {
            Thread sender = new Thread(SendThread);
            sender.Start();
        }


        /// <summary>
        /// Method that will send the commands to the server</summary>
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


        /// <summary>
        /// Gets the test to send to the server</summary>
        /// <returns>The test to send</returns>
        public string GetText()
        {
            string text = this.toSend;
            this.toSend = "";
            return text;
        }


        /// <summary>
        /// Publishes events to any of its Subscribers</summary>
        public void PublishEvent()
        {
            if (newInput != null)
            { newInput(this, EventArgs.Empty);}
        }
    }
}