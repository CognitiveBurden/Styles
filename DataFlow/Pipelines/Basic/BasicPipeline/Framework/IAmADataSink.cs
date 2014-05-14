using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    public interface IAmADataSink<T>
    {
        void Execute(IEnumerable<T> input);
    }
}