﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication5.Data;

namespace WebApplication5.Migrations
{
    [DbContext(typeof(WebsiteContext))]
    [Migration("20180601063046_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication5.Models.Complaint", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComplaintText");

                    b.Property<int>("OrganizationID");

                    b.Property<int?>("OrganizationID1");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.HasIndex("OrganizationID1");

                    b.HasIndex("UserID");

                    b.ToTable("Complaint");
                });

            modelBuilder.Entity("WebApplication5.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationID");

                    b.Property<string>("OrganizationName");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("WebApplication5.Models.User", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("OrganizationID");

                    b.Property<int?>("OrganizationID1");

                    b.HasKey("UserID");

                    b.HasIndex("OrganizationID");

                    b.HasIndex("OrganizationID1");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApplication5.Models.Complaint", b =>
                {
                    b.HasOne("WebApplication5.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApplication5.Models.Organization")
                        .WithMany("Complaints")
                        .HasForeignKey("OrganizationID1");

                    b.HasOne("WebApplication5.Models.User")
                        .WithMany("Complaints")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication5.Models.User", b =>
                {
                    b.HasOne("WebApplication5.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApplication5.Models.Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationID1");
                });
#pragma warning restore 612, 618
        }
    }
}
