using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQPipeline
{
    public static class PipelineExtensions
    {
        public static IEnumerable<string> CircularShift(this IEnumerable<string> source)
        {
            foreach (string item in source)
            {
                var shifts = new List<string>();
                var words = item.Split(' ');
                for (var i = 0; i <= words.Length - 1; i++)
                {
                    shifts.Add(string.Join(" ", words));

                    var firstWord = words[0];

                    for (int j = 1; j <= words.Length - 1; j++)
                    {
                        words[j - 1] = words[j];
                    }
                    words[words.Length - 1] = firstWord;
                }
                foreach (var shifted in shifts)
                    yield return shifted;
            }
        }

        public static IEnumerable<string> RemoveNoise(this IEnumerable<string> source, IEnumerable<string> noise)
        {
            var noiseWords = new List<string>(noise);
            foreach (var line in source)
            {

                var words = line.Split(' ');
                var threshed = new List<string>();
                foreach (var word in words)
                {
                    if (!noiseWords.Contains(word))
                        threshed.Add(word);
                }
                var newLine = string.Join(" ", threshed);
                yield return newLine;
            }
        }

        public static void Each<T>(this IEnumerable<T> collection, Action<T> doThis)
        {
            foreach(var item in collection)
            {
                doThis(item);
            }
        }
    }
}