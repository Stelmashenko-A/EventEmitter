using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Setting Get(string settingName);
    }
}
