using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Contacts")]
    public class Contact
    {
        [PrimaryKey, Identity]
        public Guid ContactId { get; set; }

        [Column(Name = "SenderUserId"), NotNull]
        public Guid SenderUserId { get; set; }

        [Column(Name = "GetterUserId"), NotNull]
        public Guid GetterUserId { get; set; }
    }
}