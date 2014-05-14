using System;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    public class ConsoleWriter : DataSink<string>
    {
        protected override void FinishWork(string line)
        {
            Console.WriteLine(line);
        }
    }
}
