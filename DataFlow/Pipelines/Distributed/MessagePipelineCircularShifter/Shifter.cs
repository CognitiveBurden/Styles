using System;
using System.Collections.Generic;
using System.Messaging;
using MessagePipelines;

namespace MessagePipelineCircularShifter
{
    public class Shifter : Consumer
    {
        private readonly Producer producer;

        public Shifter(string inputChannelName, string outputChannelName) : base(inputChannelName)
        {
            producer = new Producer(outputChannelName);
        }

        protected override bool ProcessMessage(Message message)
        {
            var type = message.Label;
            if (type == "MT_COMPLETE")
            {
                hostControl.Stop();
                return false;
            }

            var item = message.Body.ToString();
            foreach (var shifted in Shift(item))
            {
                producer.Send(shifted);
                Console.WriteLine(shifted);
            }
            return true;
        }

        protected IEnumerable<string> Shift(string line)
        {
            var shifts = new List<string>();
            var words = line.Split(' ');
            for (var i = 0; i <= words.Length - 1; i++)
            {
                shifts.Add(string.Join(" ", words));

                string firstWord = words[0];

                for (var j = 1; j <= words.Length - 1; j++)
                {
                    words[j - 1] = words[j];
                }
                words[words.Length - 1] = firstWord;
            }
            return shifts;
        }
    }
}