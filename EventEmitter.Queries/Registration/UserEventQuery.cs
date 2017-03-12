using System;
using EventEmitter.Core.Query;

namespace EventEmitter.Queries.Registration
{
    public class UserEventQuery : IQuery
    {
        public Guid UserId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
