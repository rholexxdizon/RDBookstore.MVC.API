using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RDBoookstoreAPI.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("RDBookstoreConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Overview)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pages)
                    .IsRequired();
                    

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Summary).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PublicationDate)
                    .IsRequired();

                entity.Property(e => e.ImageUrl)
                    .IsRequired();

                entity.Property(e => e.SalesRank)
                   .IsRequired();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
