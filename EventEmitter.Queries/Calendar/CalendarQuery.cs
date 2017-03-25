using System;
using EventEmitter.Core.Query;

namespace EventEmitter.Queries.Calendar
{
    public class CalendarQuery : IQuery
    {
        public Guid UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}