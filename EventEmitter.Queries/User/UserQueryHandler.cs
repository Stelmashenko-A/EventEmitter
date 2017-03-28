using System.Collections.Generic;
using System.Linq;
using EventEmitter.Core.Query;
using EventEmitter.Storage;

namespace EventEmitter.Queries.User
{
    public class UserQueryHandler : IQueryHandler<UserQuery, IEnumerable<User>>
    {
        public IEnumerable<User> Execute(UserQuery query)
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.UserAccounts
                    .Where(x => x.Name.ToLower().StartsWith(query.Name.ToLower()))
                    .OrderBy(x=>x.Name)
                    .Take(query.Count)
                    .Select(x => new User
                    {
                        UserId = x.Id,
                        UserName = x.Name
                    });

            }
        }
    }
}