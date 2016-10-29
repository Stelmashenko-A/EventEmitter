using EventEmitter.Storage.POCO;
using LinqToDB;

namespace EventEmitter.Storage
{
    public class EventEmitterDatabase : LinqToDB.Data.DataConnection
    {
        public EventEmitterDatabase() : base("EventEmitter")
        {
        }

        public ITable<Benefit> Benefits => GetTable<Benefit>();
        public ITable<BenefitType> BenefitType => GetTable<BenefitType>();
        public ITable<Claim> Claims => GetTable<Claim>();
        public ITable<Contact> Contacts => GetTable<Contact>();
        public ITable<Event> Events => GetTable<Event>();
        public ITable<EventType> EventTypes => GetTable<EventType>();
        public ITable<Message> Messages => GetTable<Message>();
        public ITable<Phone> Phones => GetTable<Phone>();
        public ITable<Registration> Registrations => GetTable<Registration>();
        public ITable<RegistrationType> RegistrationTypes => GetTable<RegistrationType>();
        public ITable<StopListRecord> StopListRecords => GetTable<StopListRecord>();
        public ITable<UserAccount> UserAccounts => GetTable<UserAccount>();
        public ITable<UserType> UserTypes => GetTable<UserType>();
        public ITable<UserTypeClaim> UserTypeClaims => GetTable<UserTypeClaim>();
        public ITable<WhiteListRecord> WhiteListRecords => GetTable<WhiteListRecord>();
        public ITable<Setting> Settings => GetTable<Setting>();

    }
}