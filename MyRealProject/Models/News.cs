using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyRealProject.Models
{
    public class News : BaseEntity 
    {
        [Display(Name = "News Title")]
        [MaxLength(200,ErrorMessage = "Maximum 200 characters")]
        public string Title { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public int Reads { get; set; }
        

        public int UserId { get; set; }
        public virtual User User { get; set; }


        public string İmage { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual Category Category { get; set; }
    }
}