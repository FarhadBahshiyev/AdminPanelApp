using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRealProject.Models
{

    public class Picture : BaseEntity
    {
        public string ImageUrl { get; set; }

        public int NewsId { get; set; }
        public virtual News News { get; set; }
    }
}