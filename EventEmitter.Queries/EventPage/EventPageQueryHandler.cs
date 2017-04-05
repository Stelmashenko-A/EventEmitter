using System;
using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Queries.Calendar;
using EventEmitter.Storage;

namespace EventEmitter.Queries.EventPage
{
    public class EventPageQueryHandler : IQueryHandler<EventPageQuery, EventPage>
    {
        protected DateTime Start { get; set; }
        protected DateTime End { get; set; }

        public EventPage Execute(EventPageQuery query)
        {
            using (var db = new EventEmitterDatabase())
            {

                var mappedQuery = from @event in db.Events
                                  where @event.Id == query.Id
                                  from account in db.UserAccounts.Where(item => item.Id == @event.EventCreatorId)
                                  select new EventPage
                                  {
                                      Id = @event.Id,
                                      Name = @event.Name,
                                      Duration = @event.Duration,
                                      EventType = (EventType)@event.EventType,
                                      Price = @event.Price,
                                      Slots = @event.Slots,
                                      Start = @event.Start,
                                      TimeStamp = @event.TimeStamp,
                                      Author = account.Name,
                                      Image = @event.Image,
                                      Description = @event.Description,
                                      Type = @event.EventType == Storage.POCO.Enums.EventType.Default
                                      ? 
                                        db.StopListRecords.Any(x => x.UserAccountId == query.UserId && x.EventId == query.Id)
                                        ? RegistrationType.Forbidden
                                        : (RegistrationType)db.Registrations.Where(item => item.EventId == @event.Id && item.UserAccountId == query.UserId)
                                          .Select(x => x.Type).FirstOrDefault()
                                      :
                                        db.WhiteListRecords.Any(x => x.EventId == query.Id && x.UserAccountId == query.UserId)
                                        ? (RegistrationType)db.Registrations.Where(item => item.EventId == @event.Id && item.UserAccountId == query.UserId)
                                          .Select(x => x.Type).FirstOrDefault()
                                        : RegistrationType.Forbidden

                                  };
                return mappedQuery.FirstOrDefault();
            }
        }

        protected void Normalize(CalendarQuery query)
        {
            if (query.Date == default(DateTime))
            {
                query.Date = DateTime.Now;
            }
            Start = new DateTime(query.Date.Year, query.Date.Month, 1);
            End = Start.AddMonths(1);
        }
    }
}