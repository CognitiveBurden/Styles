using System.Collections.Generic;

namespace DomainModel
{
    class IndexController
    {
        LineStorage lines = new LineStorage();

        public IEnumerable<Line> IndexedLines
        {
            get { return lines; }
        }

        public void IndexFile(string fileName)
        {
            var input = new Input();
            input.Parse(fileName, lines);

            var shifter = new CircularShifter();
            shifter.Shift(lines);
            lines = shifter.ShiftedLines;

            var alphabetizer = new Alphabetizer();
            alphabetizer.Sort(lines);
            lines = alphabetizer.SortedLines;
        }
    }
}