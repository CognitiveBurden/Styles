using System;
using System.Collections.Generic;
using System.IO;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    public class FileDataSource : IAmADataSource<string>
    {
        private StreamReader source;

        public FileDataSource(StreamReader source)
        {
            this.source = source;

            if (source == null)
                throw new ArgumentNullException("source");
        }

        public IAmAFilter<string> Successor { get; set; }

        public IEnumerable<string> Begin()
        {
            String line;
            while ((line = source.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}