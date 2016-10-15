using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "RegistrationTypes")]
    public class RegistrationType : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "RegistrationTypeId")]
        public Guid Id { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "Description"), NotNull]
        public string Description { get; set; }
    }
}