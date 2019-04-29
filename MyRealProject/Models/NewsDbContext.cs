using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MyRealProject.Models
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext():base("NewsDbContext")
        {
            
        }

        

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<News> News{ get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}