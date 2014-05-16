using Topshelf;

namespace MessagePipelineCircularShifter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x => x.Service<CircularShifterService>(sc =>
                {
                    sc.ConstructUsing(() => new CircularShifterService());

                    // the start and stop methods for the service
                    sc.WhenStarted((s, hostcontrol) => s.Start(hostcontrol));
                    sc.WhenStopped((s, hostcontrol) => s.Stop(hostcontrol));
                }));
        }
    }
}
