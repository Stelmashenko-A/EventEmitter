using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Registrations")]
    public class Registration : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "RegistrationId")]
        public Guid Id { get; set; }

        [Column(Name = "RegistrationTypeId"), NotNull]
        public Guid RegistrationTypeId { get; set; }

        [Column(Name = "UserAccountId"), NotNull]
        public Guid UserAccountId { get; set; }

        [Column(Name = "EventId"), NotNull]
        public Guid EventId { get; set; }
    }
}