using ePhoneCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePhoneCourseWork.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(oi => new
            {
                oi.ProductId,
                oi.OrderId
            });

            modelBuilder.Entity<OrderItem>().HasOne(p => p.Product).WithMany(oi => oi.OrderItems).HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<OrderItem>().HasOne(o => o.Order).WithMany(oi => oi.OrderItems).HasForeignKey(o => o.OrderId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }  

	}
}
