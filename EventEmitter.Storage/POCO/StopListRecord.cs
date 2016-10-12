using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "StopListRecords")]
    public class StopListRecord
    {
        [PrimaryKey, Identity]
        public Guid StopListRecordId { get; set; }

        [Column(Name = "UserAccountId"), NotNull]
        public Guid UserAccountId { get; set; }

        [Column(Name = "EventId"), NotNull]
        public Guid EventId { get; set; }
    }
}