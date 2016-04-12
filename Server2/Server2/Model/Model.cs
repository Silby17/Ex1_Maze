using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Ex1_Maze;
using System.Net.Sockets;
using System.Text;

namespace Server2
{
    public class Model : IModel
    {
        private Dictionary<string, ICommandable> options;
        public event NewModelChange newModelChange;
        private string dataFromModel;
        private Dictionary<string, GeneralMaze<int>> MazeList;
        public int counter = 0;
        
        /// <summary>
        /// Constructor Method </summary>
        public Model()
        {
            this.MazeList = new Dictionary<string, GeneralMaze<int>>();
            this.options = new Dictionary<string, ICommandable>();
            CreateOptionsDictionary();
        }


        /// <summary>
        /// This method will Execute the Command that is recevied from 
        /// the presenter using the ICommandable dictionary</summary>
        /// <param Name="oList">Object List with info for executiing</param>
        /// <returns>A JSON format to be sent to client</returns>
        public void ExecuteCommandalbe(List<object> oList, Socket client)
        {
            ICommandable value;
            List<string> strList = oList.Select(s => (string)s).ToList();
            string firstWord = strList[0];

            //Checks if the execution is correct 
            if (!options.TryGetValue(firstWord, out value))
            {
                SendToClient("404 option not found", client);
            }
            //If there is no problem with the execution code, add to threadpool
            else
            {
                options[firstWord].execDone += this.OnEventHandler;
                ThreadPool.QueueUserWorkItem(new WaitCallback(
                    delegate (object state)
                    {
                        options[firstWord].Execute(oList, client, this.MazeList);
                        options[firstWord].execDone -= this.OnEventHandler;
                    }), null);
            }
        }


        /// <summary>
        /// This method will be run on a seperate thread
        /// and it will be in charge of sending data to the Client</summary>
        /// <param name="str">The string to send to Client</param>

        public void SendToClient(string msg, Socket client)
        {
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(msg);
            //Server sends welcome msg to Client
            client.Send(data, data.Length, SocketFlags.None);
        }


        /// <summary>
        /// This Method will handle any events that it receives
        /// and will figure out where the event is from
        /// and the correct way of dealing with the event</summary>
        /// <param name="sourse">The source of the event</param>
        /// <param name="args">Any event Arguments passed with the event</param>
        public void OnEventHandler(object source, EventArgs args)
        {            
            if(source is Options.Generate)
            {
                Options.Generate g1 = (Options.Generate)source;
                this.dataFromModel = g1.GetJSON();
                Socket clientToSendTo = g1.GetClientSocket();
                this.MazeList.Add(g1.GetMazeName(), g1.GetGmaze());
                SendToClient(this.dataFromModel, clientToSendTo);
                counter++;
            }
            else if(source is Options.Solve)
            {
                Options.Solve s1 = (Options.Solve)source;
                Socket clientToSend = s1.GetClientSocket();
                string JSONResultToSend = s1.GetJSON();
                SendToClient(JSONResultToSend, clientToSend);
            }
        }


        public string GetModelChange()
        {
            string toSend = this.dataFromModel;
            //Clears the string that needs to be sent
            this.dataFromModel = "";
            return toSend;
        }



        public void PublishEvent()
        {
            if(newModelChange != null)
            {
                newModelChange(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// This method will create the ICommandable dictionary
        /// with all the keys and execution options</summary>
        public void CreateOptionsDictionary()
        {
            options.Add("1", new Options.Generate());
            options.Add("2", new Options.Solve());
            options.Add("3", new Options.Multiplayer());
            options.Add("4", new Options.Play());
            options.Add("5", new Options.Close());
        }
    }
}