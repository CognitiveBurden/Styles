using System;
using System.Collections.Generic;
using System.Messaging;
using MessagePipelines;

namespace MessagePipelineSink
{
    internal class Player : Consumer
    {
        private readonly IList<string> list = new List<string>();

        public Player(string inputChannelName) : base(inputChannelName) {}

        protected override bool ProcessMessage(Message message)
        {
            string type = message.Label;
            if (type == "MT_COMPLETE")
            {
                hostControl.Stop();
                return false;
            }

            string line = message.Body.ToString();
            Console.WriteLine(line);
            return true;
        }

    }
}