using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
    }
}