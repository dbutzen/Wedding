using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTB.Wedding.BL.Models;

namespace DTB.Wedding.WebApp.Models
{
    public class WeddingDbContext : DbContext
    {
        public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options)
        {
            
        }
        public DbSet<Family> families { get; set; }
        public DbSet<Guest> guests { get; set; }
        public DbSet<Table> tables { get; set; }
        public DbSet<User> users { get; set; }
    }
}
