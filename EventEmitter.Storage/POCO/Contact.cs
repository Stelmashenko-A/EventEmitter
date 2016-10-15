using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Contacts")]
    public class Contact : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "ContactId")]
        public Guid Id { get; set; }

        [Column(Name = "SenderUserId"), NotNull]
        public Guid SenderUserId { get; set; }

        [Column(Name = "GetterUserId"), NotNull]
        public Guid GetterUserId { get; set; }
    }
}