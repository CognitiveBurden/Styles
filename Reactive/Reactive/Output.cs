using System;
using System.Collections.Generic;

namespace Reactive
{
    internal class Output
    {
        public void Print(IEnumerable<Line> lines)
        {
            foreach(var line in lines)
                Console.WriteLine(line.ToString());
        }

        public void OnItemIndexed(LineStorage sender, NewLineAddedEventArgs e)
        {
            Console.WriteLine(e.Line);
        }
    }
}