using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "UserTypeClaim")]
    public class UserTypeClaim : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "UserTypeClaimId")]
        public Guid Id { get; set; }

        [Column(Name = "ClaimId"), NotNull]
        public Guid ClaimId { get; set; }

        [Column(Name = "UserTypeId"), NotNull]
        public Guid UserTypeId { get; set; }
    }
}