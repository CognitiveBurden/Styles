namespace DomainModel
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new IndexController();
            controller.IndexFile(@"data\TestData.txt");

            var output = new Output();
            output.Print(controller.IndexedLines);
        }
    }
}
