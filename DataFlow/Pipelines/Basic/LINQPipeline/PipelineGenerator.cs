using System;
using System.Collections.Generic;
using System.IO;

namespace LINQPipeline
{
    public static class PipelineGenerator
    {
        public static IEnumerable<string> FromFile(StreamReader reader)
        {
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}