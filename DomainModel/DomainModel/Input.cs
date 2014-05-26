using System;
using System.IO;

namespace DomainModel
{
    internal class Input
    {
        public void Parse(string fileName, LineStorage lines)
        {
            var reader = new StreamReader(fileName);
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(Line.Parse(line));
            }
        }
    }
}