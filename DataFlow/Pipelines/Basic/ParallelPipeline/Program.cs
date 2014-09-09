using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            const int bufferSize = 32;
            var rawDataBuffer = new BlockingCollection<string>(bufferSize);
            var shiftedDataBuffer = new BlockingCollection<string>(bufferSize);
            var alphabetizedDataBuffer = new BlockingCollection<string>(bufferSize);

            var pump = new FileDataSource(rawDataBuffer , new StreamReader(@"data\TestData.txt"));
                
            var shifter = new CircularShifter(rawDataBuffer, shiftedDataBuffer);
            var alphabetizer = new Alphabetizer(shiftedDataBuffer, alphabetizedDataBuffer);
            var writer = new ConsoleWriter(alphabetizedDataBuffer); 

            var pipeline = new Pipeline<string>(pump: pump, sink: writer, filters: new List<IAmAFilter<string>> {shifter, alphabetizer});
            Console.WriteLine("Begin Execution At:{0}", DateTime.UtcNow);
            pipeline.Execute();
            Console.WriteLine("Stop Execution At:{0}", DateTime.UtcNow);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
