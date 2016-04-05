using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Ex1_Maze;

namespace Server2
{
    public class Model : IModel
    {
        private Dictionary<string, ICommandable> options;
        public event NewModelChange newModelChange;
        private Dictionary<string, string> resultList;
        private string dataFromModel;
        

        public Model()
        {
            
            this.resultList = new Dictionary<string, string>();
            this.options = new Dictionary<string, ICommandable>();
            CreateOptionsDictionary();
        }


        /// <summary>
        /// This method will Execute the Command that is recevied from 
        /// the presenter using the ICommandable dictionary</summary>
        /// <param Name="oList">Object List with info for executiing</param>
        /// <returns>A JSON format to be sent to client</returns>
        public void ExecuteCommandalbe(List<object> oList)
        {
            ICommandable value;
            List<string> strList = oList.Select(s => (string)s).ToList();
            string firstWord = strList[0];

            //Checks if the execution is correct 
            if (!options.TryGetValue(firstWord, out value))
            {
                Console.WriteLine("404 option not found");
            }
            //If there is no problem with the execution code, add to threadpool
            else
            {
                options[firstWord].execDone += this.OnEventHandler;
                ThreadPool.QueueUserWorkItem(new WaitCallback(
                    delegate (object state)
                    {
                        options[firstWord].Execute(oList);
                        options[firstWord].execDone -= this.OnEventHandler;
                    }), null);
            }
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
                Console.WriteLine("Event received from Genrated");
                Options.Generate g1 = (Options.Generate)source;
                
                this.dataFromModel = g1.GetJSON();
                //this.resultList.Add("1", g1.GetJSON());
                PublishEvent();
            }
            if(source is Options.Solve)
            {
                Console.WriteLine("Received Event from Closed");                    
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