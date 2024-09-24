using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAuthToken.Models
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<StoreModel> stores { get; set; }
        public DbSet<ProductModel> products { get; set; }
        public DbSet<OrederModel> oreders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StoreModel>().HasMany(s => s.products).WithOne(p => p.store).HasForeignKey(p => p.StoreId);
            builder.Entity<ProductModel>().HasMany(p => p.oreders).WithMany(o => o.products);
        }
    }
}
