using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "UserAccounts")]
    public class UserAccount
    {
        [PrimaryKey, Identity]
        public Guid UserAccountId { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "LoginProvider")]
        public string LoginProvider { get; set; }

        [Column(Name = "LoginProviderKey")]
        public string LoginProviderKey { get; set; }
        

        [Column(Name = "Base64Secret"), NotNull]
        public string Base64Secret { get; set; }

        [Column(Name = "UserTypeId"), NotNull]
        public Guid UserTypeId { get; set; }
    }
}