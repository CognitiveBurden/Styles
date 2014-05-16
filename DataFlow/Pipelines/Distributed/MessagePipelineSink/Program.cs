using Topshelf;

namespace MessagePipelineSink
{
    class Program
    {
        static void Main(string[] args)
        {
                      HostFactory.Run(x => x.Service<MessagePipelineSinkService>(sc =>
                {
                    sc.ConstructUsing(() => new MessagePipelineSinkService());

                    // the start and stop methods for the service
                    sc.WhenStarted((s, hostcontrol) => s.Start(hostcontrol));
                    sc.WhenStopped((s, hostcontrol) => s.Stop(hostcontrol));
                }));
        }
    }
}
