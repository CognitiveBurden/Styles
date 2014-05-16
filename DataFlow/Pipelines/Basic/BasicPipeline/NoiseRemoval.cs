using System.Collections.Generic;
using BasicPipeline.Framework;

namespace BasicPipeline
{
    internal class NoiseRemoval : Filter<string>
    {
        private readonly IList<string> noiseWords;

        public NoiseRemoval(IEnumerable<string> noiseWords)
        {
            this.noiseWords = new List<string>(noiseWords);
        }

        protected override string DoWork(string line)
        {
            var words = line.Split(' ');
            var threshed = new List<string>();
            foreach (var word in words)
            {
                if (!noiseWords.Contains(word))
                    threshed.Add(word);
            }
            var newLine = string.Join(" ", threshed);
            return newLine;
        }
    }
}