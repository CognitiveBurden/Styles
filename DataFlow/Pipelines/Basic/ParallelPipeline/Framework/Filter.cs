using System.Collections.Concurrent;

namespace BasicPipeline.Framework
{
    abstract public class Filter<T> : IAmAFilter<T>
    {
        protected Filter(BlockingCollection<T> input, BlockingCollection<T> output)
        {
            Input = input;
            Output = output;
        }

        public BlockingCollection<T> Input { get; private set; }
        public BlockingCollection<T> Output { get; private set; }

        public virtual void Execute()
        {
            try
            {
                foreach(var item in Input.GetConsumingEnumerable())
                {
                    DoWork(item);
                }
            }
            finally 
            {
                
                Output.CompleteAdding();
            }
        }

        protected abstract void DoWork(T obj);
    }
}
