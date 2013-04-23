
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        [StringLength(1000)]
        public string CommentDescription { get; set; }

        public int RequestID { get; set; }

        [Required]
        [Column("CommenterID")]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("RequestID")]
        public virtual Request Request { get; set; }

    }
}
