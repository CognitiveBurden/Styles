using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    interface IAmADataSource<T>
    {
        IAmAFilter<T> Successor { get; set; }
        IEnumerable<T> Begin();
    }
}
