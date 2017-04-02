using System;
using EventEmitter.Core.Query;

namespace EventEmitter.Queries.EventPage
{
    public class EventPageQuery : IQuery
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}