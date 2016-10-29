using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Settings")]
    public class Setting : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "SettingId")]
        public Guid Id { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "Value"), NotNull]
        public string Value { get; set; }
    }
}