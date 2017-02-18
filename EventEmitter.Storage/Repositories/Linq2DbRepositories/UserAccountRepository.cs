using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using EventEmitter.Storage.Models;
using EventEmitter.Storage.POCO;
using LinqToDB.SqlQuery;
using RegistrationType = EventEmitter.Storage.POCO.Enums.RegistrationType;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccount Get(string loginProvider, string providerKey)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.UserAccounts
                            where item.LoginProvider == loginProvider &&
                                  item.LoginProviderKey == providerKey
                            select item;
                return query.FirstOrDefault();
            }
        }

        public IEnumerable<User> Get(int page, int pageSize)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.UserAccounts

                            select item;

                query = query.Skip((page - 1) * pageSize).Take(pageSize);
                var mappedQuery = from user in query

                                  select new User
                                  {
                                      Id = user.Id,
                                      Name = user.Name,
                                      InterestedTotal =
                                          db.Registrations.Count(
                                              item => item.Type == RegistrationType.Interested && item.UserAccountId == user.Id),
                                      GoTotal =
                                          db.Registrations.Count(
                                              item => item.Type == RegistrationType.Go && item.UserAccountId == user.Id),
                                      LoginProvider = user.LoginProvider,
                                      Events = db.Events.Count(item => item.EventCreatorId == user.Id),
                                      Messages = db.Messages.Count(item => item.UserAccountId == user.Id),
                                      UserTypeId = user.UserTypeId,
                                      Interested = (from reg in db.Registrations
                                                    join @event in db.Events on reg.EventId equals @event.Id
                                                    where reg.Type==RegistrationType.Interested
                                                    && @event.Start >= DateTime.Now 
                                                    && reg.UserAccountId == user.Id
                                                    select reg).Count(),
                                      WillGo = (from reg in db.Registrations
                                                    join @event in db.Events on reg.EventId equals @event.Id
                                                    where reg.Type == RegistrationType.Go
                                                    && @event.Start >= DateTime.Now
                                                    && reg.UserAccountId == user.Id
                                                    select reg).Count()


                                  };
                return mappedQuery.ToArray();
            }
        }
    }
}