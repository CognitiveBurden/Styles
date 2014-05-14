using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    public interface IAmADataSource<T>
    {
        IAmAFilter<T> Successor { get; set; }
        IEnumerable<T> Begin();
    }
}
