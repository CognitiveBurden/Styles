using System.Collections.Generic;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    public class Alphabetizer : IAmAFilter<string>
    {
        public IAmAFilter<string> Successor { get; set; }
        public IEnumerable<string> Execute(IEnumerable<string> input)
        {
            var sortedList = new List<string>(input);
            sortedList.Sort();
            return sortedList;
        }
    }
}
