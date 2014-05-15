using System;
using System.IO;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            var pump = new FileDataSource(new StreamReader(@"data\TestData.txt"));
            var shifter = new CircularShifter();
            var alphabetizer = new Alphabetizer();

            pump.Successor = shifter;
            shifter.Successor = alphabetizer;
            
            var pipeline = new Pipeline<string>(pump: pump, sink: new ConsoleWriter());
            pipeline.Execute();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
