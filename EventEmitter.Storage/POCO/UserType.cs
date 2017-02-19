using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "UserTypes")]
    public class UserType : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "UserTypeId")]
        public Guid Id { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }
    }
}