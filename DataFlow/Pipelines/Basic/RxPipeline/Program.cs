using System;
using System.IO;
using System.Reactive.Linq;

namespace RxPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"data\TestData.txt";
            var observable = new StreamReader(fileName).ToObservableLines(Observable.Return(true));
            observable.ToEnumerable().Each(line => Console.WriteLine(line));


            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
