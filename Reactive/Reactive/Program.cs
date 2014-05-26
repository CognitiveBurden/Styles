namespace Reactive
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new IndexController();
            var output = new Output();
            controller.IndexedLines.ItemAdded += output.OnItemIndexed;

            controller.IndexFile(@"data\TestData.txt");

        }
    }
}
