using System;
using EventEmitter.Core.Query;

namespace EventEmitter.Queries.BlackList
{
    public class BlackListQuery : IQuery
    {
        public Guid EventId { get; set; }
    }
}