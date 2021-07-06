using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }

        [StringLength(50)]
        public string AdminPassword { get; set; }

        public bool Status { get; set; }

        public int? RoleId { get; set; }
        public virtual AdminRole AdminRole { get; set; }
    }
}
