using NewMigrationTracker.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace NewMigrationTracker.DataAccess
{
    public class NewMigrationTrackerContext : DbContext
    {
        public NewMigrationTrackerContext()
            : base("NewMigrationContext")
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestHistory> RequestHistories { get; set; }

        public class SystemInitializer : DropCreateDatabaseIfModelChanges<NewMigrationTrackerContext>
        {
            protected override void Seed(NewMigrationTrackerContext context)
            {
                var staticroles = new List<Role> {
                                               new Role {RoleName = Role.RoleType.BuildMaster.ToString()},
                                               new Role {RoleName = Role.RoleType.Admin.ToString()},
                                               new Role {RoleName = Role.RoleType.User.ToString()},
                                               new Role {RoleName = Role.RoleType.Approver.ToString()},
                                               new Role {RoleName = Role.RoleType.SuperUser.ToString()},
                                           };

                staticroles.ForEach(role => context.Roles.Add(role));

                var staticStatuses = new List<Status> {
                                                    new Status {StatusName = NewMigrationTracker.Entities.Status.StatusType.Draft.ToString()},
                                                    new Status {StatusName = NewMigrationTracker.Entities.Status.StatusType.Submitted.ToString()},
                                                    new Status {StatusName = NewMigrationTracker.Entities.Status.StatusType.Open.ToString()},
                                                    new Status {StatusName = NewMigrationTracker.Entities.Status.StatusType.Approved.ToString()},
                                                    new Status {StatusName = NewMigrationTracker.Entities.Status.StatusType.Rejected.ToString()},
                                                    new Status {StatusName = NewMigrationTracker.Entities.Status.StatusType.Migrated.ToString()},
                                                    new Status {StatusName = NewMigrationTracker.Entities.Status.StatusType.Failure.ToString()}
                                                };

                staticStatuses.ForEach((status => context.Status.Add(status)));

                context.SaveChanges();
            }
        }
    }
}
