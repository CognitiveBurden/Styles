using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    public interface IAmAFilter<T>
    {
        IAmAFilter<T> Successor { get; set; }
        IEnumerable<T> Execute(IEnumerable<T> input);

    }
}
