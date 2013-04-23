using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; }

        public int ApplicationID { get; set; }

        [ForeignKey("ApplicationID")]
        public virtual Application Application { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Release> Releases { get; set; }

    }
}
