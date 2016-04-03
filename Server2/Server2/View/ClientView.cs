using System;

namespace Server2
{
    public class ClientView : IView
    {
        private string commandToSend;
        public event NewViewChangeEvent newInput;

        /// <summary>
        /// Simple Constructor Method/// </summary>
        public ClientView()
        {}
    

        /// <summary>
        /// This function will run when there is a new input
        /// from the client that needs to be sent to the server
        /// </summary>
        /// <param name="str">The input received</param>
        public void NewInput(string str)
        {
            commandToSend = str;
            PublishEvent();
        }


        /// <summary>
        /// Sends out an event signal to all subscribers</summary>
        public void PublishEvent()
        {
            if (newInput != null)
            {
                newInput(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// Returns the string input to any request</summary>
        /// <returns>The input from the Client</returns>
        public string GetStringInput()
        {
            return this.commandToSend;
        }
    }
}
