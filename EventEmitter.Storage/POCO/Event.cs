using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Events")]
    public class Event : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "EventId")]
        public Guid Id { get; set; }

        [Column(Name = "Start"), NotNull]
        public DateTime Start { get; set; }

        [Column(Name = "Duration"), NotNull]
        public int Duration { get; set; }

        [Column(Name = "Slots"), NotNull]
        public int Slots { get; set; }

        [Column(Name = "Price"), NotNull]
        public int Price { get; set; }

        [Column(Name = "EventTypeId"), NotNull]
        public Guid EventTypeId { get; set; }

        [Column(Name = "EventCreatorId"), NotNull]
        public Guid EventCreatorId { get; set; }
    }
}