using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConnectedCamerasWeb.Models
{
    [Table("AspNetUserRoles")]
    public class AspNetUserRole
    {
        //[ForeignKey("UserId")]
        [Key]
        public string UserId { get; set; }
        //[ForeignKey("RoleId")]
        public string RoleId { get; set; }
    }
}