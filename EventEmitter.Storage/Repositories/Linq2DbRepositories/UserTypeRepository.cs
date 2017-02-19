using System;
using System.Collections.Generic;
using System.Linq;
using EventEmitter.Storage.POCO;
using LinqToDB.Common;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public IEnumerable<UserType> GetAll()
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.UserTypes.ToList();
            }
        }

        public IEnumerable<Models.UserType> GetAllModels()
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from userType in db.UserTypes
                            select new Models.UserType
                            {
                                Id = userType.Id,
                                Name = userType.Name,

                                ClaimsNumber =
                                (from userTypeClaim in db.UserTypeClaims
                                 where userTypeClaim.UserTypeId == userType.Id
                                 select userTypeClaim).Count(),

                                Users =
                                (from userAccount in db.UserAccounts
                                 where userAccount.UserTypeId == userType.Id
                                 select userAccount).Count()
                            };
                return query.ToArray();
            }
        }
    }
}