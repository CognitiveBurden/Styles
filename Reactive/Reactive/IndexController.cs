namespace Reactive
{
    class IndexController
    {
        public LineStorage IndexedLines { get; private set; }

        public IndexController()
        {
            IndexedLines = new LineStorage();
        }

        public void IndexFile(string fileName)
        {

            var input = new Input();
            var shifter = new CircularShifter();
            var alphabetizer = new Alphabetizer();

            input.Lines.ItemAdded += shifter.OnNewLine;
            shifter.ShiftedLines.ItemAdded += alphabetizer.OnShiftedLine;
            alphabetizer.SortedLines.ItemAdded += this.OnItemsSorted;

            input.Parse(fileName);
            alphabetizer.Sort();
            
        }

        private void OnItemsSorted(LineStorage sender, NewLineAddedEventArgs e)
        {
            IndexedLines.Add(e.Line);
        }
    }
}