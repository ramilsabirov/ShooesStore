using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShooesStore.Models
{
    public class ShoesContext : DbContext
    {
        public DbSet<Shoes> Shoess { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}