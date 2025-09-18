using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Models
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure JSONB columns for PostgreSQL
            modelBuilder.Entity<Product>()
                .Property(p => p.Attributes)
                .HasColumnType("jsonb");

            modelBuilder.Entity<Category>()
                .Property(c => c.AllowedAttributes)
                .HasColumnType("jsonb");

            // Optional: GIN index on product attributes for filtering
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Attributes)
                .HasMethod("GIN");
        }
    }
}
