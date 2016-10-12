using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "EventTypes")]
    public class EventType
    {
        [PrimaryKey, Identity]
        public Guid EventTypeId { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "Description"), NotNull]
        public string Description { get; set; }
    }
}