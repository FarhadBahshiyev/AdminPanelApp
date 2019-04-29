using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyRealProject.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        private DateTime Date = DateTime.Now;

        private bool Active = true;
        
        public DateTime UploadDate
        {
            get => Date; 
            set { Date = value; }

        }

        public bool IsActive
        {
            get => Active;
            set { Active = value; }
        }

    }
}