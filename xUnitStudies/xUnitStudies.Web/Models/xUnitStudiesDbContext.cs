using System;
using Microsoft.EntityFrameworkCore;

namespace xUnitStudies.Web.Models
{
    public partial class xUnitStudiesDbContext : DbContext
    {
        public xUnitStudiesDbContext()
        {
        }

        public xUnitStudiesDbContext(DbContextOptions<xUnitStudiesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Price);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}