using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
