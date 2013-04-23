
using System.ComponentModel.DataAnnotations;

namespace NewMigrationTracker.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserDomain { get; set; }
    }
}
