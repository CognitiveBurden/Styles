using System.Collections.Generic;
using System.Linq;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    public class Alphabetizer : IAmAFilter<string>
    {
        public IAmAFilter<string> Successor { get; set; }
        public IEnumerable<string> Execute(IEnumerable<string> input)
        {
            return from line in input
                   orderby line descending 
                select line;
        }
    }
}
