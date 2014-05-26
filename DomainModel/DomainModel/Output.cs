using System;
using System.Collections.Generic;

namespace DomainModel
{
    internal class Output
    {
        public void Print(IEnumerable<Line> lines)
        {
            foreach(var line in lines)
                Console.WriteLine(line.ToString());
        }
    }
}