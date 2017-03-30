using System;
using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Storage;

namespace EventEmitter.Queries.WhiteList
{
    public class WhiteListQueryHandler : IQueryHandler<WhiteListQuery, WhiteListQueryResponce>
    {
        protected DateTime Start { get; set; }
        protected DateTime End { get; set; }

        public WhiteListQueryResponce Execute(WhiteListQuery query)
        {
            using (var db = new EventEmitterDatabase())
            {
                var responce = db.Events.Where(x => x.Id == query.EventId).Select(x => new WhiteListQueryResponce
                {
                    EventName = x.Name,
                    EventStart = x.Start
                }).FirstOrDefault();

                if (responce != null)
                {
                    responce.Records = from whiteListRecord in db.WhiteListRecords
                        where whiteListRecord.EventId == query.EventId
                        join userAccount in db.UserAccounts on whiteListRecord.UserAccountId equals userAccount.Id
                        select new WhiteListRecord
                        {
                            Id = whiteListRecord.Id,
                            Added = whiteListRecord.Added,
                            Description = whiteListRecord.Description,
                            User = userAccount.Name,
                            UserId = userAccount.Id
                        };

                }
                return responce;
            }
        }
    }
}