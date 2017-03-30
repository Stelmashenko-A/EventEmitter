using System;
using EventEmitter.Core.Query;

namespace EventEmitter.Queries.WhiteList
{
    public class WhiteListQuery : IQuery
    {
        public Guid EventId { get; set; }
    }
}