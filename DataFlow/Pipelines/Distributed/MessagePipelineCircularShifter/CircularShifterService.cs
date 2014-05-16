using Topshelf;

namespace MessagePipelineCircularShifter
{
    internal class CircularShifterService: ServiceControl
    {
        private readonly Shifter shifter;

        public CircularShifterService()
        {
            shifter = new Shifter ("shift", "sort");
        }

        public bool Start(HostControl hostControl)
        {
            shifter.Start(hostControl);
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            shifter.Stop();
            return true;
        }
    }
}