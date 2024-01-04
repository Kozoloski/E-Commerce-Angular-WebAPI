using Microsoft.EntityFrameworkCore;
using PlantShop.Domain.Entities;
using PlantShop.Domain.Entities.OrderAggregate;
using System.Reflection;

namespace PlantShop.DataAccess.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantType> PlantTypes { get; set; }
        public DbSet<PlantCategory> PlantCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
