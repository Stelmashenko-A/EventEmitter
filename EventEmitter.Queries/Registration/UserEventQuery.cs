using System;
using EventEmitter.Core.Query;

namespace EventEmitter.Queries.Registration
{
    public class UserEventQuery : IQuery
    {
        public Guid UserId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool OnlyGo { get; set; }
        public bool OnlyInterested { get; set; }
        public bool OnlyPast { get; set; }
        public bool OnlyNext { get; set; }
    }
}
