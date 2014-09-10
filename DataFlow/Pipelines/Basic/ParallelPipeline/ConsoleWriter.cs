using System;
using System.Collections.Concurrent;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    public class ConsoleWriter : DataSink<string>
    {
        public ConsoleWriter(BlockingCollection<string> input) 
            : base(input)
        {
        }

        protected override void FinishWork(string line)
        {
            Console.WriteLine(line);
        }
    }
}
