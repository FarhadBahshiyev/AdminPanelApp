using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MyRealProject.Models
{
    [Table("User")]
    public class User : BaseEntity
    {

        [MaxLength(20,ErrorMessage = "Maximum 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter E-mail")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage = "Incorrect email adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}