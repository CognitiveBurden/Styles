using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicPipeline.Framework
{
    internal class Pipeline<T>
    {
        private readonly IAmADataSink<T> sink;
        private readonly IEnumerable<IAmAFilter<T>> filters;
        private readonly IAmADataSource<T> pump;

        public Pipeline(IAmADataSource<T> pump, IAmADataSink<T> sink, IEnumerable<IAmAFilter<T>> filters)
        {
            this.pump = pump;
            this.sink = sink;
            this.filters = filters;
        }

        public void Execute()
        {
            var tf = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
            var filterStages = new List<Task>();

            filterStages.Add(tf.StartNew(() => sink.Execute()));
            filterStages.AddRange(filters.Select(thisFilter => tf.StartNew(thisFilter.Execute)));
            filterStages.Add(tf.StartNew(() => pump.Begin()));

            Task.WaitAll(filterStages.ToArray());
        }
    }
}