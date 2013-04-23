
using NewMigrationTracker_Services.Interfaces;
using System.Web.Mvc;

namespace NewMigrationTracker.Controllers
{
    [Authorize]
    public class SecureMigrationTrackerController<T> : BaseMigrationTrackerController<T>
    {
        protected IService<T> service { get; private set; }

        public SecureMigrationTrackerController(IService<T> service)
        {
            this.service = service;
        }

    }
}
