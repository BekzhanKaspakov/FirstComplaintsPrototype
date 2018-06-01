using WebApplication5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
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

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            //base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity(typeof(Complaint))
            .HasOne(typeof(Organization), "Organization")
            .WithMany()
            .HasForeignKey("OrganizationID")
            .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
            
            modelBuilder.Entity(typeof(User))
            .HasOne(typeof(Organization), "Organization")
            .WithMany()
            .HasForeignKey("OrganizationID")
            .OnDelete(DeleteBehavior.Restrict); // no ON DELETE

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Complaint>().ToTable("Complaint");
            modelBuilder.Entity<Organization>().ToTable("Organization");
            
            
        }

        public DbSet<WebApplication5.Models.Organization> Organization { get; set; }
    }
}
