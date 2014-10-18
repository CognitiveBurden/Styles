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
            #region Modify to add a new requirement
                /*.RemoveNoise(PipelineGenerator.FromFile(new StreamReader(@"data\noise.txt")))*/
            #endregion
                .OrderBy(line => line)
                .Each(Console.WriteLine);
                
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
