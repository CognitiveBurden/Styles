using Topshelf;

namespace MessagePipelineAlphabetizer
{
    internal class AlphabetizerService: ServiceControl
    {
        private readonly Alphabetizer alphabetizer;

        public AlphabetizerService()
        {
            alphabetizer = new Alphabetizer("sort", "show");
        }

        public bool Start(HostControl hostControl)
        {
            alphabetizer.Start(hostControl);
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            alphabetizer.Stop();
            return true;
        }
    }
}