using System.Collections.Concurrent;

namespace BasicPipeline.Framework
{
    public interface IAmADataSource<T>
    {
        BlockingCollection<T> Output { get;}
        void Begin();
    }
}
