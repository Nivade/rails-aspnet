using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls.Expressions;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Rails.Models
{

    public class RolePermission
    {
        [Key]
        [Column(Order = 1)]
        public string RoleId { get; set; }

        public virtual IdentityRole Role { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PermissionId { get; set; }

        public virtual Permission Permission { get; set; }

    }

}