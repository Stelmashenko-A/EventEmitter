using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Benefit")]
    public class Benefit
    {
        [PrimaryKey, Identity]
        public Guid BenefitId { get; set; }

        [Column(Name = "BenefitTypeId"), NotNull]
        public Guid BenefitTypeId { get; set; }

        [Column(Name = "UserAccountId"), NotNull]
        public Guid UserAccountId { get; set; }

        [Column(Name = "EventId"), NotNull]
        public Guid EventId { get; set; }
    }
}