using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConnectedCamerasWeb.Models
{
    [Table("AspNetUserRoles")]
    public class AspNetUserRole
    {
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        [ForeignKey("RoleId")]
        public string RoleId { get; set; }
    }
}