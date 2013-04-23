using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        [Required]
        [StringLength(250)]
        public string TaskName { get; set; }

        [StringLength(500)]
        public string TaskDescription { get; set; }

        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
    }
}
