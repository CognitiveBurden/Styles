using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    public interface IAmADataSink<T>
    {
        BlockingCollection<T> Input { get;} 
        void Execute();
    }
}