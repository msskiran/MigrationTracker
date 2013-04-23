using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestID { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Required]
        [Column("CreatedBy")]
        public int UserID { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int ReleaseID { get; set; }

        [ForeignKey("StatusID")]
        public virtual Status Status { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("ReleaseID")]
        public virtual Release Release { get; set; }
    }
}
