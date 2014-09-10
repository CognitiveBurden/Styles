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

            #region Modifying the requirement - add a 'noise' list to remove words from the index

            var noiseWords = new FileDataSource(new StreamReader(@"data\noise.txt")).Begin();
            var noiseRemover = new NoiseRemoval(noiseWords);

            #endregion

            pump.Successor = noiseRemover;
            noiseRemover.Successor = shifter;
            shifter.Successor = alphabetizer;
            
            var pipeline = new Pipeline<string>(pump: pump, sink: new ConsoleWriter());
            Console.WriteLine("Begin Execution At:{0}", DateTime.UtcNow);
            pipeline.Execute();
            Console.WriteLine("Stop Execution At:{0}", DateTime.UtcNow);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
