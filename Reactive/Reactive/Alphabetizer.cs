using System.Collections.Generic;
using System.Linq;

namespace Reactive
{
    internal class Alphabetizer
    {
        private readonly List<Line> lines = new List<Line>();
        public LineStorage SortedLines { get; private set; }

        public Alphabetizer()
        {
            SortedLines = new LineStorage();
        }

        public void Sort()
        {
            foreach(var line in lines.OrderBy(line => line))
                SortedLines.Add(line);
        }

        public void OnShiftedLine(LineStorage sender, NewLineAddedEventArgs e)
        {
            lines.Add(e.Line);
        }
    }
}