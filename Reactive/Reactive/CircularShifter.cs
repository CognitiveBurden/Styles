using System.Collections.Generic;

namespace Reactive
{
    internal class CircularShifter
    {
        public LineStorage ShiftedLines { get; private set; }

        public CircularShifter()
        {
            ShiftedLines = new LineStorage();
        }

        public void OnNewLine(LineStorage sender, NewLineAddedEventArgs newLineAddedEventArgs)
        {
            var line = newLineAddedEventArgs.Line;
            var shifts = new LineStorage();
            shifts.ItemAdded += OnShiftAdded;
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
        }

        private void OnShiftAdded(LineStorage sender, NewLineAddedEventArgs e)
        {
            ShiftedLines.Add(e.Line); 
        }
    }
}