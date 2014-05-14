using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    interface IAmAFilter<T>
    {
        IAmAFilter<T> Successor { get; set; }
        IEnumerable<T> Execute(IEnumerable<T> input);

    }
}
