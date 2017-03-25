using System;
using EventEmitter.Core.Query;

namespace EventEmitter.Queries.ICalendar
{
    public class IcalendarQuery : IQuery
    {
        public Guid EventId { get; set; }
    }
}
