using System;
using System.IO;

namespace Reactive
{
    internal class Input
    {
        public Input()
        {
            Lines = new LineStorage();
        }

        public LineStorage Lines { get; private set; }

        public void Parse(string fileName)
        {
            var reader = new StreamReader(fileName);
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                Lines.Add(Line.Parse(line));
            }
        }
    }
}