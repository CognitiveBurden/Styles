using System.Collections.Generic;

namespace BasicPipeline.Framework
{
    class DataSink<T> : IAmADataSink<T>
    {
        public void Execute(IEnumerable<T> input)
        {
            var enumerator = input.GetEnumerator();
            while (enumerator.MoveNext()) ;
        }
    }
}
