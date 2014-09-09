using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    public class Alphabetizer : IAmAFilter<string>
    {
        public Alphabetizer(BlockingCollection<string> input, BlockingCollection<string> output)
        {
            Input = input;
            Output = output;
        }

        public BlockingCollection<string> Input { get; private set; }
        public BlockingCollection<string> Output { get; private set; }
        public void Execute()
        {
            try
            {
                var sortedList = new List<string>();
                while (!Input.IsAddingCompleted || !Input.IsCompleted)
                {
                    sortedList.AddRange(Input.GetConsumingEnumerable());
                }

                sortedList.Sort();

                foreach(var sortedItem in sortedList)
                    Output.Add(sortedItem);

            }
            finally 
            {
                
                Output.CompleteAdding();
            }
        }
    }
}
