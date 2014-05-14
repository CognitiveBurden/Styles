using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    internal interface IAmADataSink<T>
    {
        void Execute(IEnumerable<T> input);
    }
}