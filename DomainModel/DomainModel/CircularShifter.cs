using System.Collections.Generic;

namespace DomainModel
{
    internal class CircularShifter
    {
        private readonly LineStorage shiftedLines = new LineStorage();

        public void Shift(IEnumerable<Line> lineStorage)
        {
            foreach (var item in lineStorage)
            {
                foreach (Line shifted in ShiftLine(item))
                    ShiftedLines.Add(shifted);
            }
        }

        public LineStorage ShiftedLines
        {
            get { return shiftedLines; }
        }

        protected IEnumerable<Line> ShiftLine(Line line)
        {
            var shifts = new LineStorage();
            var newLine = new Line(line);
            for (var i = 0; i <= line.Length - 1; i++)
            {
                shifts.Add(newLine);
                line = newLine;
                newLine = new Line(line);

                var firstWord = line[0];

                for (var j = 1; j <= line.Length - 1; j++)
                {
                    newLine[j - 1] = line[j];
                }
                newLine[ line.Length - 1] = firstWord;
            }
            return shifts;
        }

    }
}