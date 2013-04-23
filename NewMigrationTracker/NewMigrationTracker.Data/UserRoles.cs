using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class UserRoles
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        [Key, Column(Order = 1)]
        public int RoleID { get; set; }

        [Key, Column(Order = 2)]
        public int ApplicationID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        [ForeignKey("ApplicationID")]
        public virtual Application Application { get; set; }
    }
}
