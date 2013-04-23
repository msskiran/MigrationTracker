using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationID { get; set; }

        [Required]
        [StringLength(100)]
        public string ApplicationName { get; set; }

        public int TeamID { get; set; }

        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        //  public virtual TeamData TeamData { get; set; }
        //   
    }
}
