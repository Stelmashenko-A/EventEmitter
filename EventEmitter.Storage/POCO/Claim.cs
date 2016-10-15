using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Claims")]
    public class Claim : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "ClaimId")]
        public Guid Id { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }     
    }
}