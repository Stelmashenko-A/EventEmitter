using System;

namespace EventEmitter.Core.Query
{
    public class QueryHandlerNotFoundException : Exception
    {
        public QueryHandlerNotFoundException(Type type)
        {
        }
    }
}
