
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusID { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }

        public enum StatusType
        {
            Draft,
            Submitted,
            Open,
            Approved,
            Rejected,
            Migrated,
            Failure
        }
    }
}
