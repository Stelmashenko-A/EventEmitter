using System;

namespace EventEmitter.Core.Query
{
    public class QueryValidationException : Exception
    {
        public QueryValidationException(string message)
            : base(message)
        {
        }
    }
}