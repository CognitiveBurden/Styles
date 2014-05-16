using Topshelf;

namespace MessagePipelineSink
{
    internal class MessagePipelineSinkService: ServiceControl
    {
        private readonly Player player;

        public MessagePipelineSinkService ()
        {
            player = new Player("show");
        }

        public bool Start(HostControl hostControl)
        {
            player.Start(hostControl);
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            player.Stop();
            return true;
        }
    }
}