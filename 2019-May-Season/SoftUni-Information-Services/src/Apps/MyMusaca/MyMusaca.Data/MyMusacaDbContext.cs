using Microsoft.EntityFrameworkCore;
using MyMusaca.Models;

namespace MyMusaca.Data
{
    public class MyMusacaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasMany(order => order.Products);
                entity.HasOne(order => order.Cashier);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
