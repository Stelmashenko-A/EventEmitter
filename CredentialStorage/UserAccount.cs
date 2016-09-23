using System;
using LinqToDB.Mapping;

namespace CredentialStorage
{
    [Table(Name = "UserAccount")]
    public class UserAccount
    {
        [PrimaryKey, Identity]
        public Guid UserAccountId { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "LoginProvider"), NotNull]
        public string LoginProvider { get; set; }

        [Column(Name = "Base64Secret"), NotNull]
        public string Base64Secret { get; set; }

        [Column(Name = "ApplicationId"), NotNull]
        public Guid ApplicationId { get; set; }
    }
}