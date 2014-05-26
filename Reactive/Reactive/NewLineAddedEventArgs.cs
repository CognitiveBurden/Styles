using System;

namespace Reactive
{
    class NewLineAddedEventArgs : EventArgs
    {
        private Line line;

        public NewLineAddedEventArgs(Line line)
        {
            this.line = line;
        }

        public Line Line
        {
            get { return line; }
        }
    }
}
