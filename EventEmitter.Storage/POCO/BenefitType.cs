using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "BenefitTypes")]
    public class BenefitType
    {
        [PrimaryKey, Identity]
        public Guid BenefitTypeId { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "Description"), NotNull]
        public string Description { get; set; }
    }
}