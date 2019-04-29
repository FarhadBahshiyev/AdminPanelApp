using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyRealProject.Models
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        [Display(Name = "Role Name")]
        [MinLength(3,ErrorMessage = "Minimum 3 charackters"),MaxLength(15,ErrorMessage = "Maximum 15 characters")]
        public string RoleName { get; set; }
    }
}