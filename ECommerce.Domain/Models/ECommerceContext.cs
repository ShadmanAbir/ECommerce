using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Domain.Models
{
    public class ECommerceContext : IdentityDbContext
    {
        public ECommerceContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<UserBlockList> UserBlockList { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SellPost> SellPosts { get; set; }
        public DbSet<SellPostWiseTag> SellPostWiseTag { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
