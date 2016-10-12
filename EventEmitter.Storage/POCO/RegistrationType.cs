using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "RegistrationTypes")]
    public class RegistrationType
    {
        [PrimaryKey, Identity]
        public Guid RegistrationTypeId { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "Description"), NotNull]
        public string Description { get; set; }
    }
}