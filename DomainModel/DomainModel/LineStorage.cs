
using System.Collections;
using System.Collections.Generic;

namespace DomainModel
{
    internal class LineStorage : IEnumerable<Line>
    {
        readonly List<Line> lines = new List<Line>();
  
        public void Add(Line newLine)
        {
            lines.Add(newLine);
        }

        public IEnumerator<Line> GetEnumerator()
        {
            return ((IEnumerable<Line>) lines).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}