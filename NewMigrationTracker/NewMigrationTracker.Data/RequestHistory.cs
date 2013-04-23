using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class RequestHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestID { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Required]
        [Column("UpdatedBy")]
        public int UserID { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("StatusID")]
        public virtual Status Status { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
