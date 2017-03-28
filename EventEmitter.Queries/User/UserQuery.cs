using EventEmitter.Core.Query;

namespace EventEmitter.Queries.User
{
    public class UserQuery : IQuery
    {
        public string Name { get; set; }

        public int Count { get; set; }
    }
}
