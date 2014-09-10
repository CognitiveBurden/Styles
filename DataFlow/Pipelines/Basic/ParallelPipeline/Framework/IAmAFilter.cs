using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    public interface IAmAFilter<T>
    {
        BlockingCollection<T> Input { get;}
        BlockingCollection<T> Output { get;} 
        void Execute();
    }
}
