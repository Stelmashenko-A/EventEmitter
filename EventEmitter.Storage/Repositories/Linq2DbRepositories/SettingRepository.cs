using System.Linq;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class SettingRepository : Repository<Setting>,  ISettingRepository
    {
        public Setting Get(string settingName)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.Settings
                    where item.Name == settingName
                    select item;
                return query.FirstOrDefault();
            }
        }
    }
}