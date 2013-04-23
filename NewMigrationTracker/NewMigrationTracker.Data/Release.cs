using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class Release
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReleaseID { get; set; }

        [StringLength(100)]
        public string ReleaseName { get; set; }

        [StringLength(250)]
        public string BusinessLabel { get; set; }

        [StringLength(250)]
        public string SourceControlLabel { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
