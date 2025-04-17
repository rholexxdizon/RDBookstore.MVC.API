using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RDBookstoreMVC2.Models
{
    public partial class BooksDbContext : DbContext
    {
        public BooksDbContext()
        {
        }

        public BooksDbContext(DbContextOptions<BooksDbContext> options)
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
                   .IsRequired();
                   

                entity.Property(e => e.Genre)
                    .IsRequired();
                   

                entity.Property(e => e.Overview)
                    .IsRequired();
                   

                entity.Property(e => e.Pages)
                    .IsRequired();



                entity.Property(e => e.Publisher)
                    .IsRequired();
                    

                entity.Property(e => e.Summary).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired();
                    

                entity.Property(e => e.PublicationDate)
                    .IsRequired();
                entity.Property(e => e.ImageUrl)
                    .IsRequired();

                entity.Property(e => e.ISBN)
                    .IsRequired();

                entity.Property(e => e.SalesRank)
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
