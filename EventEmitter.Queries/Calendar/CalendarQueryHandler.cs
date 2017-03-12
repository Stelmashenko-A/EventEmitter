using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Storage;
using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Ical.Net.Serialization.iCalendar.Serializers;

namespace EventEmitter.Queries.Calendar
{
    public class CalendarQueryHandler : IQueryHandler<CalendarQuery, string>
    {
        public string Execute(CalendarQuery query)
        {
            Storage.POCO.Event @event;
            using (var db = new EventEmitterDatabase())
            {
                @event = db.Events.FirstOrDefault(x => x.Id == query.EventId);

            }
            if (@event == null)
            {
                return string.Empty;
            }
            var start = @event.Start;
            var end = start.AddMinutes(@event.Duration);

            var e = new Event
            {
                DtStart = new CalDateTime(start),
                DtEnd = new CalDateTime(end),
            
            };

            var calendar = new Ical.Net.Calendar();
            calendar.Events.Add(e);
            calendar.Version = "2.0";

            var serializer = new CalendarSerializer(new SerializationContext());
            return serializer.SerializeToString(calendar);
        }
    }
}