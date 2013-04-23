
using NewMigrationTracker.Entities;

namespace NewMigrationTracker.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(NewMigrationTrackerContext context)
            : base(context)
        {

        }
    }
}
