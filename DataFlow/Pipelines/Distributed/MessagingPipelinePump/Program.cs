using System;
using System.IO;
using MessagePipelines;

namespace MessagingPipelinePump
{
    class Program
    {
        private const string channel = "shift";
        static void Main(string[] args)
        {
            var source = new StreamReader(@"data\TestData.txt");
            var producer = new Producer(channel);

            String line;
            while ((line = source.ReadLine()) != null)
            {
                producer.Send(line);
            }
           
            producer.End();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }
    }
}
