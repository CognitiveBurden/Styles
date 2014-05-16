using System;
using System.IO;
using System.Linq;

namespace LINQPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            PipelineGenerator.FromFile(new StreamReader((@"data\TestData.txt")))
                .CircularShift()
                .OrderBy(line => line)
                .Each(Console.WriteLine);
                
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
