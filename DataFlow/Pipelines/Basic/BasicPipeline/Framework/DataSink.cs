using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    public class DataSink<T> : IAmADataSink<T>
    {
        public virtual void Execute(IEnumerable<T> input)
        {
            PullStream(input);
        }

        private void PullStream(IEnumerable<T> input)
        {
            var enumerator = input.GetEnumerator();
            while (enumerator.MoveNext())
            {
                FinishWork(enumerator.Current);
            }
        }

        protected virtual void FinishWork(T obj)
        {
            //default is do nothing, just exercise pipeline
            //only override for a terminal step
        }
    }
}
