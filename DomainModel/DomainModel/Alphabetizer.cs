using System.Collections.Generic;
using System.Linq;

namespace DomainModel
{
    internal class Alphabetizer
    {
        private readonly LineStorage lineStorage = new LineStorage();

        public LineStorage SortedLines
        {
            get { return lineStorage; }
        }

        public void Sort(IEnumerable<Line> lines)
        {
            foreach(var line in lines.OrderBy(line => line))
                lineStorage.Add(line);
        }
    }
}