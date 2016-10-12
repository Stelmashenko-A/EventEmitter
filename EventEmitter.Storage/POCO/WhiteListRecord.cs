using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "WhiteListRecords")]
    public class WhiteListRecord
    {
        [PrimaryKey, Identity]
        public Guid WhiteListRecordId { get; set; }

        [Column(Name = "UserAccountId"), NotNull]
        public Guid UserAccountId { get; set; }

        [Column(Name = "EventId"), NotNull]
        public Guid EventId { get; set; }
    }
}
