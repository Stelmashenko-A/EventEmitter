using System;
using LinqToDB.Mapping;

namespace CredentialStorage
{
    [Table(Name = "Application")]
    public class Application
    {
        [PrimaryKey, Identity]
        public Guid ApplicationId { get; set; }

        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "ApplicationBase64Secret"), NotNull]
        public string ApplicationBase64Secret { get; set; }
    }
}