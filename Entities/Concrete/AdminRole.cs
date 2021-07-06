using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class AdminRole
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(1)]
        public string RoleName { get; set; }

        public List<Admin> Admins { get; set; }
    }
}
