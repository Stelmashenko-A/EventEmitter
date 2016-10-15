using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Benefit")]
    public class Benefit : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "BenefitTypeId")]
        public Guid Id { get; set; }

        [Column(Name = "BenefitTypeId"), NotNull]
        public Guid BenefitTypeId { get; set; }

        [Column(Name = "UserAccountId"), NotNull]
        public Guid UserAccountId { get; set; }

        [Column(Name = "EventId"), NotNull]
        public Guid EventId { get; set; }
    }
}