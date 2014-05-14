using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    internal class Pipeline<T>
    {
        public IAmADataSource<T> Pump { get; set; }
        public IAmADataSink<T> Sink { get; set; }

        public void Execute()
        {
            //we chain the deferred execution of enumerable
            IEnumerable<T> current = Pump.Begin();
            var nextStep = Pump.Successor;
            while (nextStep != null)
            {
                current = nextStep.Execute(current);
                nextStep = nextStep.Successor;
            }

            //now when we enumerate the sink, we pull in; this is a pull based pipeline as opposed to a push based one
            Sink.Execute(current);
        }
    }
}