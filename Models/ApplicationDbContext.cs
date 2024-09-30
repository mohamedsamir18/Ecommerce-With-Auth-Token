using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAuthToken.Models
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Store> stores { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Oreder> oreders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Store>().HasMany(s => s.products).WithOne(p => p.store).HasForeignKey(p => p.StoreId);
            builder.Entity<Product>().HasMany(p => p.oreders).WithMany(o => o.products);
        }
    }
}
