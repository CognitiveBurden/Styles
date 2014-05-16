using System;
using System.Collections.Generic;
using System.Messaging;
using MessagePipelines;

namespace MessagePipelineAlphabetizer
{
    internal class Alphabetizer : Consumer
    {
        private readonly List<string> list = new List<string>();
        private readonly Producer producer;

        public Alphabetizer(string inputChannelName, string outputChannelName) : base(inputChannelName)
        {
            producer = new Producer(outputChannelName);
        }

        protected override bool ProcessMessage(Message message)
        {
            string type = message.Label;
            if (type == "MT_COMPLETE")
            {
                SendSortedIndex();
                producer.End();
                hostControl.Stop();
                return false;
            }

            string item = message.Body.ToString();
            list.Add(item);
            return true;
        }

        private void SendSortedIndex()
        {
            list.Sort();
            foreach (var line in list)
            {
                producer.Send(line);
                Console.WriteLine(line);
            }
        }
    }
}