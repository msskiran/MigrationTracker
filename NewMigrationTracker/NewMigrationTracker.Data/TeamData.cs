
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class TeamData
    {
        [Key, Column(Order = 0)]
        public int TeamID { get; set; }

        [Key, Column(Order = 1)]
        public int ApplicationID { get; set; }

        [Key, Column(Order = 2)]
        public int ProjectID { get; set; }

        [Key, Column(Order = 3)]
        public int TaskID { get; set; }

        [ForeignKey("TeamID")]
        public virtual Team Teams { get; set; }

        [ForeignKey("ApplicationID")]
        public virtual Application Applications { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Projects { get; set; }

        [ForeignKey("TaskID")]
        public virtual Task Tasks { get; set; }
    }
}
