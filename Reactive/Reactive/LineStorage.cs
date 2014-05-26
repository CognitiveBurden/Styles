using System.Collections;
using System.Collections.Generic;

namespace Reactive
{
    internal delegate void ChangedEventHandler(LineStorage sender, NewLineAddedEventArgs e);

    internal class LineStorage 
    {
        readonly List<Line> lines = new List<Line>();

        internal event ChangedEventHandler ItemAdded;
  
        public void Add(Line newLine)
        {
            lines.Add(newLine);
            OnItemAdded(new NewLineAddedEventArgs(newLine));
        }

        void OnItemAdded(NewLineAddedEventArgs e) 
        {
            if (ItemAdded!= null)
                ItemAdded(this, e);
        }
    }
}