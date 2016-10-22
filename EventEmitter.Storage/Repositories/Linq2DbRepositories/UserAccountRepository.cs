using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
       /* public IEnumerable<UserAccount> Get(Event @event, EventType eventType)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.Events
                            where item.EventCreatorId == userAccount.Id
                            select item;
                return query.ToArray();
            }
        }*/
    }
}