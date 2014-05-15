using System.Collections.Generic;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    public class CircularShifter : IAmAFilter<string>
    {
        public IAmAFilter<string> Successor { get; set; }

        public IEnumerable<string> Execute(IEnumerable<string> input)
        {
            foreach (string item in input)
            {
                foreach (string shifted in Shift(item))
                    yield return shifted;
            }
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