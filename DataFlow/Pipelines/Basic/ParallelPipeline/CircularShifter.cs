using System.Collections.Concurrent;
using System.Collections.Generic;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    public class CircularShifter : Filter<string>
    {
        public CircularShifter(BlockingCollection<string> input, BlockingCollection<string> output) 
            : base(input, output)
        {
        }

        protected override void DoWork(string item)
        {
            foreach (string shifted in Shift(item))
                Output.Add(shifted);
        }

        protected IEnumerable<string> Shift(string line)
        {
            var shifts = new List<string>();
            var words = line.Split(' ');
            for (var i = 0; i <= words.Length - 1; i++)
            {
                shifts.Add(string.Join(" ", words));

                var firstWord = words[0];

                for (var j = 1; j <= words.Length - 1; j++)
                {
                    words[j - 1] = words[j];
                }
                words[ words.Length - 1] = firstWord;
            }
            return shifts;
        }

    }
}