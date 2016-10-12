using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "UserType")]
    public class UserType
    {
        [PrimaryKey, Identity]
        public Guid UserTypeId { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "ApplicationBase64Secret"), NotNull]
        public string ApplicationBase64Secret { get; set; }
    }
}