using System;
using System.Collections.Concurrent;
using System.IO;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    public class FileDataSource : IAmADataSource<string>
    {
        private readonly StreamReader source;

        public FileDataSource(BlockingCollection<string> output, StreamReader source)
        {
            Output = output;
            this.source = source;

            if (source == null)
                throw new ArgumentNullException("source");
        }


        public BlockingCollection<string> Output { get; private set; }

        public void Begin()
        {
            try
            {
                String line;
                while ((line = source.ReadLine()) != null)
                {
                    Output.Add(line);
                }
            }
            finally
            {
                Output.CompleteAdding();
            }
        }
    }
}