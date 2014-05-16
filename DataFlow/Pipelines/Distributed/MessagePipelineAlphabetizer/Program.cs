using Topshelf;

namespace MessagePipelineAlphabetizer
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x => x.Service<AlphabetizerService>(sc =>
                {
                    sc.ConstructUsing(() => new AlphabetizerService());

                    // the start and stop methods for the service
                    sc.WhenStarted((s, hostcontrol) => s.Start(hostcontrol));
                    sc.WhenStopped((s, hostcontrol) => s.Stop(hostcontrol));
                }));
        }
    }
}
