using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewMigrationTracker.Entities
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public enum RoleType
        {
            BuildMaster,
            Admin,
            Approver,
            User,
            SuperUser
        }
    }
}
