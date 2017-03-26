using System;
using System.Collections.Generic;
using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Storage;

namespace EventEmitter.Queries.BlackList
{
    public class BlackListQueryHandler : IQueryHandler<BlackListQuery, BlackListQueryResponce>
    {
        protected DateTime Start { get; set; }
        protected DateTime End { get; set; }

        public BlackListQueryResponce Execute(BlackListQuery query)
        {
            using (var db = new EventEmitterDatabase())
            {
                var responce = db.Events.Where(x => x.Id == query.EventId).Select(x => new BlackListQueryResponce
                {
                    EventName = x.Name,
                    EventStart = x.Start
                }).FirstOrDefault();

                if (responce != null)
                {
                    responce.Records = from stopListRecord in db.StopListRecords
                        where stopListRecord.EventId == query.EventId
                        join userAccount in db.UserAccounts on stopListRecord.UserAccountId equals userAccount.Id
                        select new BlackListRecord
                        {
                            Id = stopListRecord.Id,
                            Added = stopListRecord.Added,
                            Description = stopListRecord.Description,
                            User = userAccount.Name,
                            UserId = userAccount.Id
                        };

                }
                return responce;
            }
        }
    }
}