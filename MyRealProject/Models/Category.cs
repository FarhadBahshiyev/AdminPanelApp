using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyRealProject.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public string URL { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<News> News { get; set; } 
    }
}