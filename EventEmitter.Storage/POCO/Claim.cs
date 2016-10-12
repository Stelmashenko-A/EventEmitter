using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Claims")]
    public class Claim
    {
        [PrimaryKey, Identity]
        public Guid ClaimId { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }     
    }
}