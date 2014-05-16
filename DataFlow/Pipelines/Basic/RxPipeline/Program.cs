using System;
using System.IO;
using System.Reactive.Linq;

namespace RxPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            var observable = new StreamReader(@"data\TestData.txt").ToObservableLines(new FileSystemWatcher(@"data\TestData.txt").Watch(WatcherChangeTypes.Changed));
            observable.ToEnumerable().Each(line => Console.WriteLine(line));

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
