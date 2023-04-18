using AssignmentMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Contexts
{
    public class DataContexts : DbContext
    {
        public DataContexts(DbContextOptions<DataContexts> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("Money");
                entity.Property(e => e.IsNew).IsRequired();
                entity.Property(e => e.IsPopular).IsRequired();
                entity.Property(e => e.IsFeatured).IsRequired();
            });
        }
    }
}

