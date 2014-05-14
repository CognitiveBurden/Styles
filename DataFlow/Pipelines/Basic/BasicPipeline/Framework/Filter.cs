using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    abstract public class Filter<T> : IAmAFilter<T>
    {
        public IAmAFilter<T> Successor { get; set; }
        public virtual IEnumerable<T> Execute(IEnumerable<T> input)
        {
            foreach(var item in input)
            {
                var next = DoWork(item);
                yield return next;
            }
        }

        protected abstract T DoWork(T obj);
    }
}
