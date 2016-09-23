using LinqToDB;

namespace CredentialStorage
{
    public class AuthorizationServerDatabase : LinqToDB.Data.DataConnection
    {
        public AuthorizationServerDatabase() : base("AuthorizationServer")
        {
        }

        public ITable<Application> Application => GetTable<Application>();

        public ITable<UserAccount> UserAccount => GetTable<UserAccount>();
    }
}