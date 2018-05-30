using WebApplication5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Data
{
    public class WebsiteContext : DbContext
    {
        public WebsiteContext(DbContextOptions<WebsiteContext> options) : base(options)
        {

        }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Complaint>().ToTable("Complaint");
        }
    }
}
