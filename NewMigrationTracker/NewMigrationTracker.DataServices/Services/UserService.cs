using NewMigrationTracker.DataAccess.Repositories;
using NewMigrationTracker.Entities;
using NewMigrationTracker_Services.Interfaces;
using System.Linq;

namespace NewMigrationTracker.Services.DataServices
{
    public class UserService : BaseService<User>
    {

        public UserService(IRepository<User> userRepository)
            : base(userRepository)
        {

        }

        public User GetUserByNameAndDomain(string userName, string domain)
        {
            return this.repository.GetMany(s => (s.UserName == userName) && (s.UserDomain == domain)).SingleOrDefault();

        }

    }

}
