
using InventoryManagement.Configurations;
using InventoryManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Context
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CategoryConfiguration().Configure(modelBuilder.Entity<ProductCategory>());
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());
        }
    }
}
