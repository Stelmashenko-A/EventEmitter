using System;
using EventEmitter.Core.Query;

namespace EventEmitter.Queries.Calendar
{
    public class CalendarQuery : IQuery
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
    }
}