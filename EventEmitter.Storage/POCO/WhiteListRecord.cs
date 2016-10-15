using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "WhiteListRecords")]
    public class WhiteListRecord : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "WhiteListRecordId")]
        public Guid Id { get; set; }

        [Column(Name = "UserAccountId"), NotNull]
        public Guid UserAccountId { get; set; }

        [Column(Name = "EventId"), NotNull]
        public Guid EventId { get; set; }
    }
}
